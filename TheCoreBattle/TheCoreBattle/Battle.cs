namespace TheCoreBattle
{
    public class Battle
    {
        private Player _playerOne;
        private Player _playerTwo;

        private Player _currentPlayer;
        private Player _oppositePlayer;

        private ChatDisplay? _chatDisplay;
        private GameManager _gameManager;
        public void Run(GameManager gameManager, Player playerOne, Player playerTwo)
        {
            _gameManager = gameManager;
            _chatDisplay = new ChatDisplay();

            _playerOne = playerOne;
            _playerTwo = playerTwo;

            _currentPlayer = playerOne;
            _oppositePlayer = playerTwo;

            gameManager.SetupFirstBattle();

            while (_gameManager.RunGame)
            {

                PlayTurn();
                _currentPlayer = (_currentPlayer == _playerOne) ? _playerTwo : _playerOne;
                _oppositePlayer = (_currentPlayer == _playerOne) ? _playerTwo : _playerOne;
            }
        }
        private void PlayTurn()
        {
            for (int i = 0; i < _currentPlayer.myCharacterList.Count; i++)
            {

                Character characterThatAttacks = _currentPlayer.myCharacterList[i];
                _chatDisplay.DisplayBattleState(_currentPlayer, _oppositePlayer, characterThatAttacks);


                _chatDisplay.DisplayTurn(characterThatAttacks);

                IBattleAction action = DecideAction(characterThatAttacks);
                Character targetCharacter = GetTargetCharacter();

                BattleContext context = new BattleContext()
                {
                    CurrentCharacter = characterThatAttacks,
                    Target = targetCharacter,

                    CurrentPlayer = _currentPlayer,
                    OppositePlayer = _oppositePlayer,
                    
                    ChatDisplay = _chatDisplay,
                    GameManager = _gameManager
                };
                action.Execute(context);

                _gameManager.CheckIfCharacterDies(_oppositePlayer);
                _gameManager.VerifyBattleState(_currentPlayer, _oppositePlayer);
            }
        }
        private IBattleAction DecideAction(Character characterThatAttacks)
        {
            int actionToMake;
            if (_currentPlayer.IsHuman)
            {
                List<int> allowedChar = CheckAvailableMoves(characterThatAttacks);
                actionToMake = _chatDisplay.DisplayAvailableAction(allowedChar, characterThatAttacks, _currentPlayer);
            }
            else
            {
                actionToMake = AIGetAction(characterThatAttacks);
                Thread.Sleep(100);
            }

            IBattleAction battleAction = actionToMake switch
            {
                1 => new BasicAttackAction(),
                2 => new DoNothing(),
                3 => new UsePotionAction(),
                4 => new EquipItemAction(),
                5 => new GearAttack(),
                _ => new DoNothing(),
            };
            return battleAction;
        }
        private int AIGetAction(Character characterThatAttacks)
        {
            //TODO REFACTOR, BRZYDKIE LOSOWANIE IMO
            //KAŻDE DODANIE AKCJI POWOUJE, ŻE W AI TEŻ MUSZĘ INKREMENTOWAĆ ILOŚC AKCJI 
            int chosenAction = 1;
            if (_currentPlayer.ItemManager.PartyConsumableItems.Count != 0 && characterThatAttacks.CurrentHealth < (characterThatAttacks.MaxHealth / 2))
            {
                if (Random.Shared.Next(0, 4) == 0) chosenAction = 3;
                else
                {
                    chosenAction = Random.Shared.Next(1, 3);
                }
            }
            else if (characterThatAttacks.HasGearEquipped() == true || _currentPlayer.ItemManager.PartyItems.Count >0)
            {
                    if (Random.Shared.Next(0, 2) == 0) chosenAction = 4;
            }
            else if (characterThatAttacks.HasGearEquipped())
            {
                chosenAction = 5;
            }
            else
            {
                chosenAction = Random.Shared.Next(1, 3);
            }
            return chosenAction;
        }
        private List<int> CheckAvailableMoves(Character characterThatAttacks)
        {
            List<int> allowedChar = new List<int> { 1, 2 };
            if (_currentPlayer.ItemManager.PartyConsumableItems.Count != 0) allowedChar.Add(3);
            if (_currentPlayer.ItemManager.PartyItems.Count != 0 || characterThatAttacks.HasGearEquipped()) allowedChar.Add(4);
            if (characterThatAttacks.HasGearEquipped()) allowedChar.Add(5);
            if (_currentPlayer.ItemManager.PartyItems.Count != 0) allowedChar.Add(10);

            return allowedChar;
        }
        public Character GetTargetCharacter()
        {
            //TO DO ADD AI 
            int indexOfCharacter;
            if (_oppositePlayer.myCharacterList.Count == 1) return _oppositePlayer.myCharacterList[0];

            if (!_currentPlayer.IsHuman)
            {
                indexOfCharacter = Random.Shared.Next(_oppositePlayer.myCharacterList.Count);
            }
            else
            {

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pick which character you want to attack?");
                    _oppositePlayer.DisplayAllTeamCharacters();
                    if (int.TryParse(Console.ReadLine(), out int I))
                    {
                        if (I <= _oppositePlayer.myCharacterList.Count)
                        {
                            indexOfCharacter = I;
                            break;
                        }
                    }
                }
            }
            //tutaj wywala, gdy czasem nie złapie tego, że gra się skończyła
            // potecnajlny problem, gdy zabije akcja pierwszeog potwora, do sprawdzenia
            return _oppositePlayer.myCharacterList[indexOfCharacter];
        }
    }
    //public enum BattleAction { BasicAttack, Nothing, ConsumableItem, EquipItem, GearAttack }
}
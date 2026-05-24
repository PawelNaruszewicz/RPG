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
                Character targetCharacter = _oppositePlayer.myCharacterList[0];
                _chatDisplay.DisplayBattleState(_currentPlayer, _oppositePlayer, characterThatAttacks);


                _chatDisplay.DisplayTurn(characterThatAttacks);
                int actionToMake = DecideAction(characterThatAttacks);
                UseAction(actionToMake, characterThatAttacks, targetCharacter);

                _gameManager.VerifyBattleState(_currentPlayer, _oppositePlayer);
            }
        }
        private int DecideAction(Character characterThatAttacks)
        {
            int actionToMake;
            if (_currentPlayer.IsHuman)
            {
                actionToMake = _chatDisplay.GetAction(characterThatAttacks, _currentPlayer);
            }
            else
            {
                actionToMake = AIGetAction(characterThatAttacks);
                Thread.Sleep(1000);
            }

            return actionToMake;
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
            else if (characterThatAttacks.HasGearEquipped() == false)
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
        //to do refaktor tutaj się przyda, jest najebane różnnych rzeczy, battle odpowiada za za dużo rzeczy?
        private void UseAction(int chosenAction, Character characterThatAttacks, Character targetCharacter)
        {
            bool normalAttack = true;

            if (chosenAction == 2)
                characterThatAttacks.DoNothingAction.Run(characterThatAttacks);
            else if (chosenAction == 3)
            {
                //usuwanie po idkach gdy dodam więcej potków, tak jak w itemkach
                characterThatAttacks.UsePotionAction.Run(characterThatAttacks, _currentPlayer.ItemManager.PartyConsumableItems[0]);
                _currentPlayer.ItemManager.PartyConsumableItems.Remove(_currentPlayer.ItemManager.PartyConsumableItems[0]);
            }
            else if (chosenAction == 4)
            {
                if (characterThatAttacks.HasGearEquipped())
                {
                    characterThatAttacks.EquipGear.ManipulateItems(characterThatAttacks, _currentPlayer, characterThatAttacks.ItemEquipped);
                }
                else
                {
                    DecideWhichItemToEquip(characterThatAttacks);
                }

            }
            else if (chosenAction == 5)
            {
                normalAttack = false;
                characterThatAttacks.UseBasicAction.Run(characterThatAttacks, targetCharacter, _chatDisplay, normalAttack);
            }
            else
            {
                normalAttack = true;
                characterThatAttacks.UseBasicAction.Run(characterThatAttacks, targetCharacter, _chatDisplay, normalAttack);
            }
            _gameManager.CheckIfCharacterDies(_oppositePlayer);
            Console.WriteLine();
        }
        private void DecideWhichItemToEquip(Character characterThatAttacks)
        {
            if (!_currentPlayer.IsHuman)
            {
                characterThatAttacks.EquipGear.ManipulateItems(characterThatAttacks, _currentPlayer, _currentPlayer.ItemManager.GetItemByID(0));
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Pick which item do you want to equip?");
                    _currentPlayer.ItemManager.DisplayCurrentItems();

                    string input = "";
                    if (int.TryParse(Console.ReadLine(), out int result))
                    {
                        if (result >= 0 && result < _currentPlayer.ItemManager.PartyItems.Count)
                        {
                            characterThatAttacks.EquipGear.ManipulateItems(characterThatAttacks, _currentPlayer, _currentPlayer.ItemManager.GetItemByID(result));
                            break;
                        }
                    }
                }
            }
        }


    }
}
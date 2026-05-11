namespace TheCoreBattle
{
    public class Battle
    {
        private Player _playerOne;
        private Player _playerTwo;

        private Player _currentPlayer;
        private Player _oppositePlayer;


        //private Character _characterThatAttacks;
        //private Character _targetCharacter;

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

            Character heroName = new Hero(_chatDisplay.GetHeroName());
            _playerOne.AddCharacterToMyTeam(heroName);
            _gameManager.CreateEnemiesForCurrentBattle();

            while (_gameManager.RunGame)
            {
                PlayTurn();
                _currentPlayer = (_currentPlayer == _playerOne) ? _playerTwo : _playerOne;
                _oppositePlayer = (_currentPlayer == _playerOne) ? _playerTwo : _playerOne;
            }
        }
        private int DecideAction(Character characterThatAttacks)
        {
            int actionToMake;
            string input = Random.Shared.Next(2).ToString();

            _chatDisplay.DisplayTurn(characterThatAttacks);

            actionToMake = _chatDisplay.GetAction(characterThatAttacks);

            return actionToMake;
        }
        private void PlayTurn()
        {
            for (int i = 0; i < _currentPlayer.myCharacterList.Count; i++)
            {
                
                Character characterThatAttacks = _currentPlayer.myCharacterList[i];
                Character targetCharacter = _oppositePlayer.myCharacterList[0];

                int actionToMake = DecideAction(characterThatAttacks);
                UseAction(actionToMake, characterThatAttacks, targetCharacter);

                VerifyGameChanges();
                Thread.Sleep(1000);
            }
        }

        private void VerifyGameChanges()
        {
            _gameManager.CheckIfCharacterDies(_oppositePlayer);
            _gameManager.CreateEnemiesForCurrentBattle();
            _gameManager.CheckIfGameOver(_currentPlayer, _oppositePlayer);
        }

        private void UseAction(int chosenAction, Character characterThatAttacks, Character targetCharacter)
        {
            if (chosenAction == 2)
                characterThatAttacks.DoNothingAction.Run(characterThatAttacks, targetCharacter);
            else
            {
                characterThatAttacks.UseAction.Run(characterThatAttacks, targetCharacter);
            }
            Console.WriteLine();
        }
    }
}
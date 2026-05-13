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

            Character heroName = new Hero(_chatDisplay.GetHeroName());
            _playerOne.AddCharacterToMyTeam(heroName);
            _gameManager.TryCreateEnemiesForCurrentBattle();

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
            if (_currentPlayer.IsHuman == true)
            {
                actionToMake = _chatDisplay.GetAction(characterThatAttacks);
            }
            else
            {
                actionToMake = 1;
            }
            _chatDisplay.DisplayTurn(characterThatAttacks);
            
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

                VerifyBattleState();
                Thread.Sleep(1000);
            }
        }

        private void VerifyBattleState()
        {
            _gameManager.TryCreateEnemiesForCurrentBattle();
            _gameManager.CheckIfGameOver(_currentPlayer, _oppositePlayer);
        }

        private void UseAction(int chosenAction, Character characterThatAttacks, Character targetCharacter)
        {
            if (chosenAction == 2)
                characterThatAttacks.DoNothingAction.Run(characterThatAttacks);
            else
            {
                characterThatAttacks.UseBasicAction.Run(characterThatAttacks, targetCharacter);
            }
            _gameManager.CheckIfCharacterDies(_oppositePlayer);
            Console.WriteLine();
        }
    }
}
using System.Runtime.CompilerServices;

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

            SetupFirstBattle();

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


                int actionToMake = DecideAction(characterThatAttacks);
                UseAction(actionToMake, characterThatAttacks, targetCharacter);

                VerifyBattleState();
            }
        }
        private int DecideAction(Character characterThatAttacks)
        {
            //TODO
            // DODAĆ WERYFIKACJE POTIONÓW, CZY SĄ W EQ ->WTEDY DOPIERO POWINNA BYĆ OPCJA BY SIĘ WYŚWIETLAŁY / DO UŻYCIA
            int actionToMake;
            if (_currentPlayer.IsHuman == true)
            {
                actionToMake = _chatDisplay.GetAction(characterThatAttacks);
            }
            else
            {
                actionToMake = AIUseAction();
                Thread.Sleep(1000);
            }
            _chatDisplay.DisplayTurn(characterThatAttacks);

            return actionToMake;
        }
        private int AIUseAction()
        {
           //TODO
           //DODAĆ LOGIKE LOSOWANIA TEGO CO MA AI ZROBIĆ
           //CZYLI TUTAJ TEŻ TRZEBA PATRZEĆ CZY ON W OGÓLE MOŻE ZROBIĆ DANE AKCJE
            return 1;
        }
        private void UseAction(int chosenAction, Character characterThatAttacks, Character targetCharacter)
        {
            if (chosenAction == 2)
                characterThatAttacks.DoNothingAction.Run(characterThatAttacks);
            else if (chosenAction == 3)
            {
                characterThatAttacks.UsePotionAction.Run(characterThatAttacks, _currentPlayer.partyItems[0], _currentPlayer);
            }
            else
            {
                characterThatAttacks.UseBasicAction.Run(characterThatAttacks, targetCharacter);
            }
            _gameManager.CheckIfCharacterDies(_oppositePlayer);
            Console.WriteLine();
        }


        private void SetupFirstBattle()
        {
            Character heroName = new Hero(_chatDisplay.GetHeroName());
            _playerOne.AddCharacterToMyTeam(heroName);
            _gameManager.TryCreateEnemiesForCurrentBattle();

            Potion potion = new Potion();
            Potion potionEnemy = new Potion();
            _playerOne.AddItemsToMyTeam(potion);
            _playerTwo.AddItemsToMyTeam(potionEnemy);
        }

       

        private void VerifyBattleState()
        {
            _gameManager.TryCreateEnemiesForCurrentBattle();
            _gameManager.CheckIfGameOver(_currentPlayer, _oppositePlayer);
        }

    }
}
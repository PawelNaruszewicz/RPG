namespace TheCoreBattle
{
    public class GameManager
    {
        private Player _playerOne;
        private Player _playerTwo;
        private Player _monsterPlayer;
        private GameMode _currentGameMode;

        public bool RunGame = true;
        ChatDisplay chatDisplay = new ChatDisplay();
        private int currentBattleIndex = 0;
        public void Run()
        {
            _playerOne = new Player(Team.Player);
            _playerTwo = new Player(Team.Enemy);
            _monsterPlayer = _playerTwo;
            Battle battle = new Battle();
            ChooseGameMode();
            battle.Run(this, _playerOne, _playerTwo, _currentGameMode);
        }
        public void CheckIfCharacterDies(Player oppositePlayer)
        {
            if (oppositePlayer.myCharacterList[0].CurrentHealth <= 0)
            {
                chatDisplay.DisplayCharacterDeath(oppositePlayer.myCharacterList[0]);
                oppositePlayer.CharacterDied(oppositePlayer.myCharacterList[0]);
            }
        }
        public void CheckIfGameOver(Player player, Player playerTwo)
        {
            if (player.myCharacterList.Count == 0) EndGame(playerTwo, player);
            else if (playerTwo.myCharacterList.Count == 0) EndGame(player, playerTwo);
        }
        public void EndGame(Player playerWon, Player playerLost)
        {
            chatDisplay.EndGameDisplay(playerWon, playerLost);
            RunGame = false;
        }
        public void TryCreateEnemiesForCurrentBattle()
        {
            if (_monsterPlayer.myCharacterList.Count != 0) return;
            if (currentBattleIndex == 0)
            {
                Character enemySkeleton = new Skeleton();
                _monsterPlayer.AddCharacterToMyTeam(enemySkeleton);
            }
            else if (currentBattleIndex == 1)
            {
                Character enemySkeleton1 = new Skeleton();
                Character enemySkeleton2 = new Skeleton();
                _monsterPlayer.AddCharacterToMyTeam(enemySkeleton1);
                _monsterPlayer.AddCharacterToMyTeam(enemySkeleton2);
            }
            else if (currentBattleIndex == 2)
            {
                Character theUncodedOne = new UncodedOne();
                _monsterPlayer.AddCharacterToMyTeam(theUncodedOne);
            }
            currentBattleIndex++;
        }
        public void ChooseGameMode()
        {
            int chosenGameMode = chatDisplay.GetGameMode();
            switch(chosenGameMode)
            {
                case 1:
                    _currentGameMode = new GameMode(GameModeType.PlayerVsPc);
                    break;
                case 2:
                    _currentGameMode = new GameMode(GameModeType.PcVsPc);
                    break;
                case 3:
                    _currentGameMode = new GameMode(GameModeType.PlayerVsPlayer);
                    break;
            }
            Console.WriteLine($"{_currentGameMode.CurrentGameMode} has been activated");
        }

    }
}

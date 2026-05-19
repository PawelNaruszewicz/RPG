namespace TheCoreBattle
{
    public class GameManager
    {
        private Player _playerOne;
        private Player _playerTwo;
        private Player _monsterPlayer;

        public bool RunGame = true;
        ChatDisplay chatDisplay = new ChatDisplay();
        private int currentBattleIndex = 0;
        public void Run()
        {
            ChooseGameMode(out bool playerOneBool, out bool playerTwoBool);

            _playerOne = new Player(Team.Player, playerOneBool);
            _playerTwo = new Player(Team.Enemy, playerTwoBool);

            _monsterPlayer = _playerTwo;
            Battle battle = new Battle();
            battle.Run(this, _playerOne, _playerTwo);
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
                
                Potion potion = new Potion();
                Potion potionTwo = new Potion();
                _monsterPlayer.ItemManager.AddConsumableItem(potion);
                _monsterPlayer.ItemManager.AddConsumableItem(potionTwo);

                Dagger dagger = new Dagger();
                Dagger daggerTwo = new Dagger();
                _monsterPlayer.ItemManager.AddItems(dagger);
                _monsterPlayer.ItemManager.AddItems(daggerTwo);
            }
            else if (currentBattleIndex == 2)
            {
                Character theUncodedOne = new UncodedOne();
                _monsterPlayer.AddCharacterToMyTeam(theUncodedOne);
                Potion potion = new Potion();
                _monsterPlayer.ItemManager.AddConsumableItem(potion);
            }
            currentBattleIndex++;
        }
        public void ChooseGameMode(out bool playerOneBool, out bool playerTwoBool)
        {
            int chosenGameMode = chatDisplay.GetGameMode();
            bool _playerOneBool = true;
            bool _playerTwoBool = false;

            switch (chosenGameMode)
            {
                case 1:
                    _playerOneBool = true;
                    _playerTwoBool = false;
                    break;
                case 2:
                    _playerOneBool = false;
                    _playerTwoBool = false;
                    break;
                case 3:
                    _playerOneBool = true;
                    _playerTwoBool = true;
                    break;
            }
            playerOneBool = _playerOneBool;
            playerTwoBool = _playerTwoBool;
        }
    }
}

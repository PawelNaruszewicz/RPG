namespace TheCoreBattle
{
    public class GameManager
    {
        public Random? random;
        public Player OppositePlayer;
        
        private ChatDisplay? chatDisplay;
        private bool RunGame = true;
        private int currentBattleIndex = 0;
        private Player monsterPlayer;
        public void Run()
        {
            random = new Random();
            chatDisplay = new ChatDisplay();

            Player playerOne = new Player(Team.Player);
            Player playerTwo = new Player(Team.Enemy);
            monsterPlayer = playerTwo;

            Player currentPlayer = playerOne;
            OppositePlayer = playerTwo;

            Character heroName = new Hero(chatDisplay.GetHeroName());
            playerOne.AddCharacterToMyTeam(heroName);
            CreateEnemiesForCurrentBattle();



            while (RunGame)
            {
                PlayTurn(currentPlayer, OppositePlayer);
                currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
                OppositePlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
            }
        }
        private void PlayTurn(Player currentPlayer, Player oppositePlayer)
        {
            for (int i = 0; i < currentPlayer.myCharacterList.Count; i++)
            {
                DecideAction(currentPlayer.myCharacterList[i], currentPlayer, oppositePlayer);
                Thread.Sleep(1000);
            }
        }
        private void DecideAction(Character character, Player currentPlayer, Player oppositePlayer)
        {
            int actionToMake;
            string input = random.Next(2).ToString();

            actionToMake = chatDisplay.GetAction(character);
            //BŁAD
            //zadaje obrażenia nawet jak stoje afk

            //REFACTOR tego
            //tutaj jest pierdolnik, to trzeba przerobic
            chatDisplay.DisplayChat(character, actionToMake, oppositePlayer, this);
            CheckIfCharacterDies(oppositePlayer);

            CreateEnemiesForCurrentBattle();
            CheckIfGameOver(currentPlayer, oppositePlayer);
        }

        private void CheckIfCharacterDies(Player oppositePlayer)
        {
            if (oppositePlayer.myCharacterList[0].CurrentHealth <= 0)
            {
                chatDisplay.DisplayCharacterDeath(oppositePlayer.myCharacterList[0]);
                oppositePlayer.CharacterDied(oppositePlayer.myCharacterList[0]);
            }
        }
        private void CheckIfGameOver(Player player, Player playerTwo)
        {
            if (player.myCharacterList.Count == 0) EndGame(playerTwo, player);
            else if (playerTwo.myCharacterList.Count == 0) EndGame(player, playerTwo);
        }
        private void EndGame(Player playerWon, Player playerLost)
        {
            chatDisplay.EndGameDisplay(playerWon, playerLost);
            RunGame = false;
        }
        private void CreateEnemiesForCurrentBattle()
        {
            if (monsterPlayer.myCharacterList.Count != 0) return;
            if (currentBattleIndex == 0)
            {
                Character enemySkeleton = new Skeleton();
                monsterPlayer.AddCharacterToMyTeam(enemySkeleton);
            }
            else if (currentBattleIndex == 1)
            {
                Character enemySkeleton1 = new Skeleton();
                Character enemySkeleton2 = new Skeleton();
                monsterPlayer.AddCharacterToMyTeam(enemySkeleton1);
                monsterPlayer.AddCharacterToMyTeam(enemySkeleton2);
            }
            else if (currentBattleIndex == 2)
            {
                Character theUncodedOne = new UncodedOne();
                monsterPlayer.AddCharacterToMyTeam(theUncodedOne);
            }
            currentBattleIndex++;
        }
        private void ChooseGameMode()
        {
            int chosenGameMode = chatDisplay.GetGameMode();
            switch(chosenGameMode)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

    }
}

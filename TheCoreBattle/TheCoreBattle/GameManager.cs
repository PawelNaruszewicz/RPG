namespace TheCoreBattle
{
    internal class GameManager
    {
        private ChatDisplay? chatDisplay;
        public Random? random;
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
            Player oppositePlayer = playerTwo;

            Character heroName = new Character(chatDisplay.GetHeroName(), 25);
            playerOne.AddCharacterToMyTeam(heroName);
            CreateEnemiesForCurrentBattle();



            while (RunGame)
            {
                PlayTurn(currentPlayer, oppositePlayer);
                currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
                oppositePlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
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
            Action actionToMake;
            string input = random.Next(2).ToString();


            while (true)
            {
                //TODO DODAĆ BOOL CZY GRACZ CZY AI GRA
                //int input2 = 1;

                foreach (var action in character.AvailableAction)
                {
                    Console.WriteLine($"{action.Key} - {action.Value.Name}");
                }
                int input2 = Convert.ToInt32(Console.ReadLine());
                if (character.AvailableAction.ContainsKey(input2))
                {
                    actionToMake = character.AvailableAction[input2];
                    break;
                }
            }

            actionToMake.DealDamage(oppositePlayer.myCharacterList[0]);
            chatDisplay.DisplayChat(character, actionToMake, oppositePlayer);
            
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
                Character enemySkeleton = new Character("SKELETON", 5);
                monsterPlayer.AddCharacterToMyTeam(enemySkeleton);
            }
            else if (currentBattleIndex == 1)
            {
                Character enemySkeleton1 = new Character("SKELETON", 5);
                Character enemySkeleton2 = new Character("SKELETON", 5);
                monsterPlayer.AddCharacterToMyTeam(enemySkeleton1);
                monsterPlayer.AddCharacterToMyTeam(enemySkeleton2);
            }
            else if(currentBattleIndex == 2)
            {
                Character theUncodedOne = new Character("THE UNCODED ONE", 15);
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

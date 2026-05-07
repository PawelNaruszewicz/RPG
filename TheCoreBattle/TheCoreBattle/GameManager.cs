namespace TheCoreBattle
{
    internal class GameManager
    {
        private ChatDisplay? chatDisplay;
        public Random? random;
        public void Run()
        {
            random = new Random();
            chatDisplay = new ChatDisplay();

            Player playerOne = new Player(Team.Player);
            Player playerTwo = new Player(Team.Enemy);

            Player currentPlayer = playerOne;
            Player oppositePlayer = playerTwo;

            Character heroName = new Character(chatDisplay.GetHeroName(), 25);
            playerOne.AddCharacterToMyTeam(heroName);

            Character enemySkeleton = new Character("SKELETON", 5);
            playerTwo.AddCharacterToMyTeam(enemySkeleton);
            Character enemySkeleton2 = new Character("SKELETON", 5);
            playerTwo.AddCharacterToMyTeam(enemySkeleton2);

            while (true)
            {
                //Console.WriteLine($"BEFORE DEBUG CURRENT PLAYER -{currentPlayer.Team} / opposite - {oppositePlayer.Team}");

                PlayTurn(currentPlayer, oppositePlayer);
                currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
                oppositePlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
                //Console.WriteLine($"AFTER DEBUG CURRENT PLAYER -{currentPlayer.Team} / opposite - {oppositePlayer.Team}");
            }
        }
        private void PlayTurn(Player currentPlayer, Player oppositePlayer)
        {
            for (int i = 0; i < currentPlayer.myCharacterList.Count; i++)
            {
                DecideAction(currentPlayer.myCharacterList[i], oppositePlayer);
                Thread.Sleep(1000);
            }
        }
        private void DecideAction(Character character, Player oppositePlayer)
        {
            Action actionToMake;
            string input = random.Next(2).ToString();

            //foreach(var availableActio in character.AvailableAction)
            //{
            //    Console.WriteLine($"ID - {availableActio.Key} Name of attack - {availableActio.Value.Name}");
            //}

            while (true)
            {
                //int input2 = Convert.ToInt32(Console.ReadLine());
                int input2 = 1;
                if (character.AvailableAction.ContainsKey(input2))
                {
                    actionToMake = character.AvailableAction[input2];
                    break;
                }
            }

            actionToMake.DealDamage(oppositePlayer.myCharacterList[0]);
            if (oppositePlayer.myCharacterList[0].CurrentHealth <= 0)
            {
                oppositePlayer.CharacterDied(oppositePlayer.myCharacterList[0]);
            }
            chatDisplay.DisplayChat(character, actionToMake, oppositePlayer);

            //Action actionToMake = input switch
            //{
            //    "1" => new Action("NOTHING"),
            //    _ => new Action("NOTHING")
            //};
            //DealDamage(character, actionToMake);
            //chatDisplay.DisplayChat(character, actionToMake);
        }

    }
}

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

            Character heroName = new Character(chatDisplay.GetHeroName());
            playerOne.AddCharacterToMyTeam(heroName);

            Character enemySkeleton = new Character("SKELETON 1");
            playerTwo.AddCharacterToMyTeam(enemySkeleton);
            Character enemySkeleton2 = new Character("SKELETON 2");
            playerTwo.AddCharacterToMyTeam(enemySkeleton2);

            while (true)
            {
                PlayTurn(currentPlayer);
                currentPlayer = (currentPlayer == playerOne) ?  playerTwo : playerOne;
            }
        }
        private void PlayTurn(Player player)
        {
            for(int i = 0; i < player.myCharacterList.Count; i++)
            {
                DecideAction(player.myCharacterList[i]);
                Thread.Sleep(1000);
            }
        }
        private void DecideAction(Character character)
        {
            string input = random.Next(2).ToString();

            Action actionToMake = input switch
            {
                "1" => new Action("NOTHING"),
                _ => new Action("NOTHING")
            };
            chatDisplay.DisplayChat(character, actionToMake);
        }

    }
}

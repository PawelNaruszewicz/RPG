namespace TheCoreBattle
{
    internal class GameManager
    {
        private ChatDisplay chatDisplay;
        public Random random;
        public void Run()
        {
            random = new Random();
            chatDisplay = new ChatDisplay();
            
            Player playerOne = new Player(Team.Player);
            Player playerTwo = new Player(Team.Enemy);

            Player currentPlayer = playerOne;

            Character heroName = new Character(chatDisplay.GetHeroName());
            playerOne.AddCharacterToMyTeam(heroName);

            Character enemySkeleton = new Character("SKELETON");
            playerTwo.AddCharacterToMyTeam(enemySkeleton);

            while (true)
            {
                Turn(currentPlayer);
                currentPlayer = (currentPlayer == playerOne) ?  playerTwo : playerOne;
            }
        }
        private void Turn(Player player)
        {
            DecideAction(player);
            Thread.Sleep(1000);
        }
        private void DecideAction(Player player)
        {
            string input = random.Next(2).ToString();

            Action actionToMake = input switch
            {
                "1" => new Action("NOTHING"),
                _ => new Action("NOTHING")
            };
            chatDisplay.DisplayChat(player, actionToMake);
        }

    }
}

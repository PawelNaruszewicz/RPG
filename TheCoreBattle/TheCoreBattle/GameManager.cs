namespace TheCoreBattle
{
    internal class GameManager
    {
        private ChatDisplay chatDisplay;
        public void Run()
        {
            chatDisplay = new ChatDisplay();
            List<Character> heroParty = new List<Character>();
            List<Character> monsterParty = new List<Character>();


            Character playerSkeleton = new Character("SKELETON", Team.Player);
            heroParty.Add(playerSkeleton);
            Character enemySkeleton = new Character("SKELETON", Team.Enemy);
            monsterParty.Add(enemySkeleton);

            while(true)
            {
                Console.ReadKey();
                Turn(playerSkeleton);
                Turn(enemySkeleton);
            }
        }
        private void Turn(Character character)
        {
            chatDisplay.DisplayChat(character);
            Thread.Sleep(500);
        }
    }
}

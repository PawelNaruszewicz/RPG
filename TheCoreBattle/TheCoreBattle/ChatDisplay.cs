using System;

namespace TheCoreBattle
{
    internal class ChatDisplay
    {
        public void DisplayChat(Player player, Action currentAction)
        {
            DisplayTurn(player);
            DisplayAction(player, currentAction);
        }
        private void DisplayTurn(Player player)
        {
            Console.WriteLine($"It is {player.myCharacterList[0].Name} turn...");
        }
        private void DisplayAction(Player player, Action currentAction)
        {
            if(currentAction.Name == "NOTHING")
                Console.WriteLine($"{player.myCharacterList[0].Name} did NOTHING\n");
            else
            {
                Console.WriteLine("Invalid action");
            }
        }
        public string GetHeroName()
        {
            string name;
            while (true)
            {
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
                if (!String.IsNullOrEmpty(name)) break;
            }
            return name;
        }
    }
}

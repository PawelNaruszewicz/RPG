using System;

namespace TheCoreBattle
{
    internal class ChatDisplay
    {
        public void DisplayChat(Character character, Action currentAction)
        {
            DisplayTurn(character);
            DisplayAction(character, currentAction);
        }
        private void DisplayTurn(Character character)
        {
            Console.WriteLine($"It is {character.Name} turn...");
        }
        private void DisplayAction(Character character, Action currentAction)
        {
            if(currentAction.Name == "NOTHING")
                Console.WriteLine($"{character.Name} did NOTHING\n");
            else
            {
                Console.WriteLine("Invalid action");
            }
        }
        public string GetHeroName()
        {
            string? name;
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

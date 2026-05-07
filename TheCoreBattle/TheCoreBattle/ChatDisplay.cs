namespace TheCoreBattle
{
    internal class ChatDisplay
    {
        public void DisplayChat(Character character, Action currentAction, Player oppositePlayer)
        {
            DisplayTurn(character);
            DisplayAction(character, currentAction, oppositePlayer);
        }
        private void DisplayTurn(Character character)
        {
            Console.WriteLine($"It is {character.Name} turn...");
        }
        private void DisplayAction(Character character, Action currentAction, Player oppositePlayer)
        {
            if (currentAction.Name == "NOTHING")
                Console.WriteLine($"{character.Name} did NOTHING");
            else
            {
                Console.WriteLine($"{character.Name} used {currentAction.Name} on {oppositePlayer.myCharacterList[0].Name}");
                Console.WriteLine($"{oppositePlayer.myCharacterList[0].Name} health equals {oppositePlayer.myCharacterList[0].CurrentHealth} / {oppositePlayer.myCharacterList[0].MaxHealth}");

            }
            Console.WriteLine();
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

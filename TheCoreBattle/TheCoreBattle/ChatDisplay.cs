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
                Console.WriteLine($"{currentAction.Name} dealt {currentAction.DamageValue} to {oppositePlayer.myCharacterList[0].Name}");
                Console.WriteLine($"{oppositePlayer.myCharacterList[0].Name} is at {oppositePlayer.myCharacterList[0].CurrentHealth} / {oppositePlayer.myCharacterList[0].MaxHealth} HP");
            }
            Console.WriteLine();
        }
        public void DisplayCharacterDeath(Character deadCharacter)
        {
            Console.WriteLine($"{deadCharacter.Name} has been defeated!");
        }
        public void EndGameDisplay(Player playerWon, Player playerLost)
        {
            Console.WriteLine($"Team {playerWon.Team} has won!");
            Console.WriteLine($"{playerLost.Team} has been defetead");
        }
        public string GetHeroName()
        {
            string? name;
            while (true)
            {
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
                if (!String.IsNullOrEmpty(name))
                {
                    Console.Clear();
                    break;
                }
            }
            return name;
        }
    }
}

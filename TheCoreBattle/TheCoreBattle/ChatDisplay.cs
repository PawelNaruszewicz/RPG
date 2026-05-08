namespace TheCoreBattle
{
    internal class ChatDisplay
    {
        public void DisplayChat(Character character, int chosenAction, Player oppositePlayer,GameManager gameManager)
        {
            DisplayTurn(character);
            DisplayAction(character, chosenAction, oppositePlayer, gameManager);
        }
        private void DisplayTurn(Character character)
        {
            Console.WriteLine($"It is {character.Name} turn...");
        }
        private void DisplayAction(Character character, int chosenAction, Player oppositePlayer, GameManager gameManager)
        {
            if (chosenAction == 2)
                character.DoNothingAction.Run(gameManager, character);
            else
            {
                character.UseAction.Run(gameManager, character);
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
        public int GetAction(Character character)
        {
            int actionIntToReturn;
            //while(true)
            //{
            //    Console.WriteLine("Decide which action you want to make");
            //    Console.WriteLine($"1 - {character.BasicAttack.Name}");
            //    Console.WriteLine($"2 - Do Nothing");

            //    //lepsza obsługas inputów, bo inaczej wyjebuje
            //    int input2 = Convert.ToInt32(Console.ReadLine());
            //    if (input2 == 1 || input2 == 2)
            //    {
            //        actionIntToReturn = input2;
            //        break;
            //    }
            //}
            return 1;
            //return actionIntToReturn;
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
        public int GetGameMode()
        {
            int input;
            Console.WriteLine("Hey, choose in what way do you want to play");
            while (true)
            {
                Console.WriteLine("Press 1 to play Player vs PC");
                Console.WriteLine("Press 2 to play PC vs PC");
                Console.WriteLine("Press 3 to play Player vs Player");
                input = Convert.ToInt32(Console.ReadLine());
                if (input > 0 && input < 4) break;
            }
            return input;
        }
    }
}

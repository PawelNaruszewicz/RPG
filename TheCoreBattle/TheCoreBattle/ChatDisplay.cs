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
                Console.WriteLine($"{character.Name} used {character.BasicAttack.Name} on {oppositePlayer.myCharacterList[0].Name}");
                Console.WriteLine($"{character.BasicAttack.Name} dealt {character.BasicAttack.DamageValue} to {oppositePlayer.myCharacterList[0].Name}");
                Console.WriteLine($"{oppositePlayer.myCharacterList[0].Name} is at {oppositePlayer.myCharacterList[0].CurrentHealth} / {oppositePlayer.myCharacterList[0].MaxHealth} HP");

                //Console.WriteLine($"{character.Name} used {currentAction.Name} on {oppositePlayer.myCharacterList[0].Name}");
                //Console.WriteLine($"{currentAction.Name} dealt {currentAction.DamageValue} to {oppositePlayer.myCharacterList[0].Name}");
                //Console.WriteLine($"{oppositePlayer.myCharacterList[0].Name} is at {oppositePlayer.myCharacterList[0].CurrentHealth} / {oppositePlayer.myCharacterList[0].MaxHealth} HP");
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

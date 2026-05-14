namespace TheCoreBattle
{
    internal class ChatDisplay
    {

        public void DisplayTurn(Character character)
        {
            Console.WriteLine($"It is {character.Name} turn...");
        }

        public void DisplayCharacterDeath(Character deadCharacter)
        {
            Console.WriteLine($"{deadCharacter.Name} has been defeated!");
        }
        public void EndGameDisplay(Player playerWon, Player playerLost)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Team {playerWon.Team} has won!");
            Console.WriteLine($"{playerLost.Team} has been defetead");
        }
        public int GetAction(Character character, Player currentPlayer)
        {
            int actionIntToReturn;
            List<int> allowedChar = new List<int> { 1, 2 };
            if (currentPlayer.partyItems.Count != 0) allowedChar.Add(3);
            if (currentPlayer.partyGear.Count != 0 || character.HasGearEquipped) allowedChar.Add(4);

            while (true)
            {
                Console.WriteLine("Decide which action you want to make");
                Console.WriteLine($"1 - {character.BasicAttack.Name}");
                Console.WriteLine($"2 - Do Nothing");

                if (currentPlayer.partyItems.Count != 0) Console.WriteLine($"3 - Use Potion");
                //to do może iterować po itemach wszystkich? trzeba by dodać opcje
                //brzydka ta logika mocno tutaj
                if (currentPlayer.partyGear.Count != 0 && character.HasGearEquipped == false) Console.WriteLine($"4 - Equip Item {currentPlayer.partyGear[0].Name}");
                else if (character.HasGearEquipped == true) Console.WriteLine($"4 - Attack Using {character.GearEquipped.Name}");
                if (int.TryParse(Console.ReadLine(), out int Y))
                {
                    if (allowedChar.Contains(Y))
                    {
                        actionIntToReturn = Y;
                        break;
                    }
                }
                Console.WriteLine();
            }
            return actionIntToReturn;
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
        public void DisplayBattleState(Player currentPlayer, Player playerTwo, Character currentCharacter)
        {
            Console.WriteLine("========================BATTLE========================");
            foreach (Character character in currentPlayer.myCharacterList)
            {
                if (character == currentCharacter)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{character.Name}\t {character.CurrentHealth}/{character.MaxHealth}");
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.WriteLine("--------------------------VS--------------------------");
            foreach (Character character in playerTwo.myCharacterList)
            {
                Console.WriteLine($"\t\t\t{character.Name}\t {character.CurrentHealth}/{character.MaxHealth}");
            }
            Console.WriteLine("======================================================");
        }
    }
}

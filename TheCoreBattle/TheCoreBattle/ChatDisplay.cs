namespace TheCoreBattle
{
    public class ChatDisplay
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
            if (currentPlayer.ItemManager.PartyConsumableItems.Count != 0) allowedChar.Add(3);
            if (currentPlayer.ItemManager.PartyItems.Count != 0 || character.HasGearEquipped()) allowedChar.Add(4);
            if (character.HasGearEquipped()) allowedChar.Add(5);
            if (currentPlayer.ItemManager.PartyItems.Count != 0) allowedChar.Add(10);

            while (true)
            {
                Console.WriteLine("Decide which action you want to make");
                Console.WriteLine($"1 - {character.BasicAttack.Name}");
                Console.WriteLine($"2 - Do Nothing");

                if (currentPlayer.ItemManager.PartyConsumableItems.Count != 0) Console.WriteLine($"3 - Use Potion");
                //brzydka ta logika mocno tutaj

                if (currentPlayer.ItemManager.PartyItems.Count != 0 && character.HasGearEquipped() == false) Console.WriteLine($"4 - Equip One Of Your Items");
                else if (character.HasGearEquipped() == true) Console.WriteLine($"4 - Unequip Item {character.ItemEquipped.Name}");

                if (character.HasGearEquipped() == true) Console.WriteLine($"5 - Attack Using {character.ItemEquipped.Name}");

                if (currentPlayer.ItemManager.PartyItems.Count != 0) Console.WriteLine("10 - Display current items");

                if (int.TryParse(Console.ReadLine(), out int Y))
                {
                    if (Y == 10)
                    {
                        currentPlayer.ItemManager.DisplayCurrentItems();
                        continue;
                    }
                    if (allowedChar.Contains(Y))
                    {
                        actionIntToReturn = Y;
                        break;
                    }
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================BATTLE========================");
            foreach (Character character in currentPlayer.myCharacterList)
            {
                if (character == currentCharacter)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{character.Name}\t {character.CurrentHealth}/{character.MaxHealth}");
                if (character.HasGearEquipped()) Console.WriteLine($"WEAPON\t {character.ItemEquipped.Name.ToUpper()}");
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.WriteLine("--------------------------VS--------------------------");
            foreach (Character character in playerTwo.myCharacterList)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t{character.Name}\t {character.CurrentHealth}/{character.MaxHealth}");
                if (character.HasGearEquipped()) Console.WriteLine($"\t\t\tWEAPON\t\t {character.ItemEquipped.Name.ToUpper()}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("======================================================");
            Console.WriteLine();
        }
        public void DisplayAttack(Character character, Character target, AttackResult attackData, bool normalAttack)
        {
            if (normalAttack)
            {
                Console.WriteLine($"{character.Name} used {character.BasicAttack.Name} on {target.Name}");
                Console.WriteLine($"{character.BasicAttack.Name} dealt {attackData.Damage} to {target.Name}");
            }
            else
            {
                Console.WriteLine($"{character.Name} used {character.ItemEquipped.Name} on {target.Name}");
                Console.WriteLine($"{character.ItemEquipped.Name} dealt {attackData.Damage} to {target.Name}");
            }

            Console.WriteLine($"{target.Name} is at {target.CurrentHealth} / {target.MaxHealth} HP");
        }
    }
}

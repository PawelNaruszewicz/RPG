
namespace TheCoreBattle
{
    public class ItemManager
    {
        public List<ConsumableItem> PartyConsumableItems { get; private set; }
        public List<Item> PartyItems { get; private set; }
        public ItemManager()
        {
            PartyConsumableItems = new List<ConsumableItem>();
            PartyItems = new List<Item>();
        }
        public void AddConsumableItem(ConsumableItem item)
        {
            PartyConsumableItems.Add(item);
        }
        public void RemoveConsumableItem(ConsumableItem item)
        {
            PartyConsumableItems.Remove(item);
        }
        public void AddItems(Item item)
        {
            PartyItems.Add(item);
        }
        public void RemoveItems(Item item)
        {
            PartyItems.Remove(item);
        }
        public void DisplayCurrentItems()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Items in party inventory are:");
            for (int i = 0; i < PartyItems.Count; i++)
            {
                Console.WriteLine($"{i} - {PartyItems[i].Name}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DisplayCurrentConsumables()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < PartyConsumableItems.Count; i++)
            {
                Console.WriteLine($"{i} - {PartyItems[i]}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public Item GetItemByID(int ID)
        {
            if(ID >=0 && ID < PartyItems.Count)
                return PartyItems[ID];
            else
            {
                Console.WriteLine("Haven't found an item in this ID, returning default dagger");
                return new Dagger();
            }
        }
        public void ManipulateEquippedItem(Character character, Item item)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (character.HasGearEquipped())
            {
                Console.WriteLine($"{character.Name} has unequipped {character.ItemEquipped.Name}");
                AddItems(character.ItemEquipped);
                character.ItemEquipped = null;
            }
            else
            {
                Console.WriteLine($"{character.Name} has equipped {item.Name}");
                character.ItemEquipped = item;
                RemoveItems(item);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void MoveItems(ItemManager playerItems, ItemManager opponentItems)
        {
            for (int i = 0; i < opponentItems.PartyItems.Count; i++)
            {
                playerItems.PartyItems.Add(opponentItems.PartyItems[i]);
                opponentItems.PartyItems.Remove(opponentItems.PartyItems[i]);
            }
            for (int i = 0; i < opponentItems.PartyConsumableItems.Count; i++)
            {
                playerItems.PartyConsumableItems.Add(opponentItems.PartyConsumableItems[i]);
                opponentItems.PartyConsumableItems.Remove(opponentItems.PartyConsumableItems[i]);
            }

        }
    }
}


namespace TheCoreBattle
{
    public class ItemManager
    {
        public List<ConsumableItem> PartyConsumableItems { get; set; }
        public List<Item> PartyItems { get; private set; }
        
        public ItemManager ()
        {
            PartyConsumableItems = new List<ConsumableItem>();
            PartyItems = new List<Item>();
        }
        public void AddConsumableItem(ConsumableItem item)
        {
            PartyConsumableItems.Add(item);
        }
        public void AddItems(Item gear)
        {
            PartyItems.Add(gear);
        }
        public void DisplayCurrentItems()
        {
            for(int i = 0; i < PartyItems.Count; i++)
            {
                Console.WriteLine($"{i} - {PartyItems[i].Name}");
            }
        }
        public void DisplayCurrentConsumables()
        {
            for (int i = 0; i < PartyConsumableItems.Count; i++)
            {
                Console.WriteLine($"{i} - {PartyItems[i]}");
            }
        }
        public Item GetItemByID(int ID)
        {
            if (PartyItems[ID] != null) return PartyItems[ID];
            else
            {
                Console.WriteLine("Haven't found an item in this ID, returning default dagger");
                return new Dagger();
            }
        }
    }
}

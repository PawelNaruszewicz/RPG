
namespace TheCoreBattle
{
    public class ItemManager
    {
        public List<ConsumableItem> partyConsumableItems { get; set; }
        public List<Item> partyItems { get; set; }
        
        public ItemManager ()
        {
            partyConsumableItems = new List<ConsumableItem>();
            partyItems = new List<Item>();
        }
        public void AddConsumableItem(ConsumableItem item)
        {
            partyConsumableItems.Add(item);
        }
        public void AddItems(Item gear)
        {
            partyItems.Add(gear);
        }
        public void DisplayCurrentItems()
        {
            for(int i = 0; i < partyItems.Count; i++)
            {
                Console.WriteLine($"{i} - {partyItems[i]}");
            }
        }
        public void DisplayCurrentConsumables()
        {
            for (int i = 0; i < partyConsumableItems.Count; i++)
            {
                Console.WriteLine($"{i} - {partyItems[i]}");
            }
        }

    }

}

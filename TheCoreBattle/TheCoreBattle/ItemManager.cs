
namespace TheCoreBattle
{
    public class ItemManager
    {
        public List<ConsumableItem> PartyConsumableItems { get; private set; }
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
            //wywala błąd jak jest poza ID
            if (PartyItems[ID] != null) return PartyItems[ID];
            else
            {
                Console.WriteLine("Haven't found an item in this ID, returning default dagger");
                return new Dagger();
            }
        }
        //TO DO, TO POWINNO ZARZĄDZAĆ ADD / REMOVE ITEM CHYBA?
        public void EquipUnequipItem(Character character, Item item)
        {
            if (character.HasGearEquipped())
            {
                AddItems(character.ItemEquipped);
                character.ItemEquipped = null;
            }
            else
            {
                character.ItemEquipped = item;
                RemoveItems(item);
            }
        }
    }
}

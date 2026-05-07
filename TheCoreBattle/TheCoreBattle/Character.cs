
namespace TheCoreBattle
{
    internal class Character
    {
        public string Name { get; set; }
        public Team Team;
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Dictionary<int, Action> AvailableAction;

        public Character(string name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;

            CreateAttackDictionary();
        }

        private void CreateAttackDictionary()
        {
            AvailableAction = new Dictionary<int, Action>();
            AvailableAction.Add(0, new Action("NOTHING"));

            if (Name == "SKELETON")
            {
                AvailableAction.Add(1, new Action("BONE CRUNCH"));
            }
            else
            {
                AvailableAction.Add(1, new Action("PUNCH"));
            }
        }

        public override string ToString()
        {
            return ($"Name is {Name}");
        }
    }
}

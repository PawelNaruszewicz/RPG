
using System;

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

            for (int i = 1; i < 2; i++)
            {
                Action actionToAdd = Name switch
                {
                    "SKELETON" => new Action("BONE CRUNCH"),
                    "THE UNCODED ONE" => new Action("UNRAVELLING ATTACK"),
                    _ => new Action("PUNCH")
                };
                AvailableAction.Add(i, actionToAdd);
            }
        }

        public override string ToString()
        {
            return ($"Name is {Name}");
        }
    }
}

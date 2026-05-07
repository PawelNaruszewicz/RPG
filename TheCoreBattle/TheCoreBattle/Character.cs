
using System;

namespace TheCoreBattle
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract IAttack BasicAttack { get; }
        public Team Team;
        
        private int _hp;
        public int CurrentHealth
        {
            get => _hp;
            set => _hp = Math.Clamp(value, 0, MaxHealth);
        }
        public int MaxHealth { get; }
        public Character(int hp, Team team)
        {
            MaxHealth = hp;
            CurrentHealth = hp;
            Team = team;
        }
        //public Dictionary<int, Action> AvailableAction;

        //private void CreateAttackDictionary()
        //{

        //    AvailableAction = new Dictionary<int, Action>();
        //    AvailableAction.Add(0, new Action("NOTHING"));

        //    for (int i = 1; i < 2; i++)
        //    {
        //        Action actionToAdd = Name switch
        //        {
        //            "SKELETON" => new Action("BONE CRUNCH"),
        //            "THE UNCODED ONE" => new Action("UNRAVELLING ATTACK"),
        //            _ => new Action("PUNCH")
        //        };
        //        AvailableAction.Add(i, actionToAdd);
        //    }
        //}

        public override string ToString()
        {
            return ($"Name is {Name}");
        }
    }
}

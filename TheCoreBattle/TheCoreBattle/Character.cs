
using System;

namespace TheCoreBattle
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract IAttack BasicAttack { get; }
        public Team Team;
        public DoNothing DoNothingAction => new DoNothing();
        public UseAction UseAction => new UseAction();

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
        public override string ToString()
        {
            return ($"Name is {Name}, Health is {CurrentHealth}, Team is {Team}, Max Health is {MaxHealth}");
        }
    }
}

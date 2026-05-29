namespace TheCoreBattle
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public Team Team;
        public abstract IAttack BasicAttack { get; }
        public Item? ItemEquipped { get; set; }
        public Modifier? Modifier { get; }

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
        public Character(int hp, Team team, Modifier modifier)
        {
            MaxHealth = hp;
            CurrentHealth = hp;
            Team = team;
            Modifier = modifier;
        }
        public override string ToString()
        {
            return ($"Name is {Name}, Health is {CurrentHealth}, Team is {Team}, Max Health is {MaxHealth}");
        }
        public bool HasGearEquipped()
        {
            if (ItemEquipped == null) return false;
            else return true;
        }
    }
}

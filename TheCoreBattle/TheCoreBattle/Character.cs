namespace TheCoreBattle
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public Team Team;
        public abstract IAttack BasicAttack { get; }

        public DoNothing DoNothingAction { get; } = new DoNothing();
        public UsePotion UsePotionAction { get; } = new UsePotion();
        public BasicAction UseBasicAction => new BasicAction();
        

        //TO DO DODAĆ SETTING ITEMÓW, sprwadzenie czy możesz
        public Item ItemEquipped { get; set; }
        //public bool HasGearEquipped = false;
        public GearAttack UseGearAction => new GearAttack();
        public GearInteraction EquipGear => new GearInteraction();

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
        public bool HasGearEquipped()
        {
            if (ItemEquipped == null) return false;
            else return true;
        }
    }
}

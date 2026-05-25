namespace TheCoreBattle
{
    public abstract class Item
    {
        public abstract string Name { get; }
        public abstract IAttack Attack { get; }
        public abstract string AttackName { get; }
    }
    public class Sword : Item
    {
        public override string Name => "Sword";
        public override IAttack Attack => new SwordAttack();
        public override string AttackName => "Sword Swing";
    }
    public class Dagger : Item
    {
        public override string Name => "Dagger";
        public override IAttack Attack => new DaggerAttack();
        public override string AttackName => "Dagger Stab";
    }
    public class Bow : Item
    {
        public override string Name => "Bow";
        public override IAttack Attack => new BowAttack();
        public override string AttackName => "Bow Shot";

    }
}

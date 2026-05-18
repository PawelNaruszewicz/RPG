namespace TheCoreBattle
{
    public abstract class Item
    {
        public abstract string Name { get; }
        public abstract IAttack Attack { get; }
    }
    public class Sword : Item
    {
        public override string Name => "Sword";
        public override IAttack Attack => new SwordAttack();
    }
    public class Dagger : Item
    {
        public override string Name => "Dagger";
        public override IAttack Attack => new DaggerAttack();
    }
}

namespace TheCoreBattle
{
    public abstract class Gear
    {
        public abstract string Name { get; }
        public abstract IAttack Attack { get; }
    }
    public class Sword : Gear
    {
        public override string Name => "Sword";
        public override IAttack Attack => new SwordAttack();
    }
    public class Dagger : Gear
    {
        public override string Name => "Dagger";
        public override IAttack Attack => new DaggerAttack();
    }
}

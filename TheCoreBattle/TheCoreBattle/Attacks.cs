namespace TheCoreBattle
{
    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public AttackResult GetAttackDamage() => new AttackResult(1);
    }
    public class BoneCrunch : IAttack
    {
        public string Name => "Bone Crunch";
        public AttackResult GetAttackDamage() => new AttackResult(Random.Shared.Next(2));


    }
    public class UnravellAttack : IAttack
    {
        public string Name => "Unravelling Attack";
        public AttackResult GetAttackDamage() => new AttackResult(Random.Shared.Next(3));
    }
    public class SwordAttack : IAttack
    {
        public string Name => "Sword Swing";
        public AttackResult GetAttackDamage() => new AttackResult(2);
    }
    public class DaggerAttack :IAttack
    {
        public string Name => "Dagger Stab";
        public AttackResult GetAttackDamage() => new AttackResult(1);
    }
}

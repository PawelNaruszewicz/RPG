namespace TheCoreBattle
{
    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public AttackResult GetAttackDamage() => new AttackResult(1, DamageType.Normal);
        public float HitChance => 1;
    }
    public class BoneCrunch : IAttack
    {
        public string Name => "Bone Crunch";
        public AttackResult GetAttackDamage() => new AttackResult(Random.Shared.Next(2), DamageType.Normal);
        public float HitChance => 1;

    }
    public class UnravellAttack : IAttack
    {
        public string Name => "Unravelling Attack";
        public AttackResult GetAttackDamage() => new AttackResult(Random.Shared.Next(5), DamageType.Decoding);
        public float HitChance => 1;

    }
    public class SwordAttack : IAttack
    {
        public string Name => "Sword Swing";
        public AttackResult GetAttackDamage() => new AttackResult(4, DamageType.Normal);
        public float HitChance => 1;
    }
    public class DaggerAttack :IAttack
    {
        public string Name => "Dagger Stab";
        public AttackResult GetAttackDamage() => new AttackResult(1, DamageType.Normal);
        public float HitChance => 1;

    }
    public class BowAttack : IAttack
    {
        public string Name => "Bow Shot";
        public AttackResult GetAttackDamage() => new AttackResult(3, DamageType.Normal);
        public float HitChance => 0.5f;


    }
}

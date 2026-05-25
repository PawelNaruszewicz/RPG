namespace TheCoreBattle
{
    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public AttackResult GetAttackDamage() => new AttackResult(1);
        public HitAccuracy GetHitChance() => new HitAccuracy(1);
    }
    public class BoneCrunch : IAttack
    {
        public string Name => "Bone Crunch";
        public AttackResult GetAttackDamage() => new AttackResult(Random.Shared.Next(2));
        public HitAccuracy GetHitChance() => new HitAccuracy(1);



    }
    public class UnravellAttack : IAttack
    {
        public string Name => "Unravelling Attack";
        public AttackResult GetAttackDamage() => new AttackResult(Random.Shared.Next(3));
        public HitAccuracy GetHitChance() => new HitAccuracy(1);

    }
    public class SwordAttack : IAttack
    {
        public string Name => "Sword Swing";
        public AttackResult GetAttackDamage() => new AttackResult(2);
        public HitAccuracy GetHitChance() => new HitAccuracy(1);

    }
    public class DaggerAttack :IAttack
    {
        public string Name => "Dagger Stab";
        public AttackResult GetAttackDamage() => new AttackResult(1);
        public HitAccuracy GetHitChance() => new HitAccuracy(1);
    }
    public class BowAttack : IAttack
    {
        public string Name => "Bow Shot";
        public AttackResult GetAttackDamage() => new AttackResult(3);
        public HitAccuracy GetHitChance() => new HitAccuracy(0.5f);

    }
}

namespace TheCoreBattle
{
    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public int DamageValue => 1;
    }
    public class BoneCrunch : IAttack
    {
        public string Name => "Bone Crunch";
        public int DamageValue => Random.Shared.Next(2);
    }
    public class UnravellAttack :IAttack
    {
        public string Name => "Unravelling Attack";
        public int DamageValue => Random.Shared.Next(3);
    }
}

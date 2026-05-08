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
        //gdy wypisuje to losuje obrażenia, więc mogę zadać obrażenie, a chat wypisze, że nie zadałem
        public int DamageValue => Random.Shared.Next(2);
    }
    public class UnravellAttack :IAttack
    {
        public string Name => "Unravelling Attack";
        public int DamageValue => Random.Shared.Next(3);
    }
}

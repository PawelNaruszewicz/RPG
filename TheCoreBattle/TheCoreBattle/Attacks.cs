using System.ComponentModel.DataAnnotations;

namespace TheCoreBattle
{
    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public AttackResult Create() => new AttackResult(1);
    }
    public class BoneCrunch : IAttack
    {
        public string Name => "Bone Crunch";
        //BŁAD 
        //gdy wypisuje to losuje obrażenia, więc mogę zadać obrażenie, a chat wypisze, że nie zadałem
        public AttackResult Create() => new AttackResult(Random.Shared.Next(2));


    }
    public class UnravellAttack :IAttack
    {
        public string Name => "Unravelling Attack";
        public AttackResult Create() => new AttackResult(Random.Shared.Next(3));
    }
}

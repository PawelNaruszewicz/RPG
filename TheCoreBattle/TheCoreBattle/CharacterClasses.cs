
namespace TheCoreBattle
{
    internal class Hero : Character
    {
        public override string Name { get; }

        //każde odwołanie tworzy nową instacje / obiekt
        //jeżeli bym chciał 
        //  public override IAttack BasicAttack => new Punch();
        public override IAttack BasicAttack { get; } = new Punch();
        public Hero(string name) : base(25, Team.Player) => Name = name;
    }
    public class Skeleton : Character
    {
        public override string Name => "SKELETON";
        public override IAttack BasicAttack { get; } = new BoneCrunch();
        public Skeleton() : base(5, Team.Enemy) { }
    }
    internal class UncodedOne : Character
    {
        public override string Name => "THE UNCODED ONE";
        public override IAttack BasicAttack { get; } = new UnravellAttack();
        public UncodedOne() : base(15, Team.Enemy) { }
    }
}

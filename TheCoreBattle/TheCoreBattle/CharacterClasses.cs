
namespace TheCoreBattle
{
    internal class Hero : Character
    {
        public override string Name { get; }
        public override IAttack BasicAttack => new Punch();
        public Hero(string name) : base(25, Team.Player) => Name = name;
    }
    public class Skeleton : Character
    {
        public override string Name => "SKELETON";
        public override IAttack BasicAttack => new BoneCrunch();
        public Skeleton() : base(5, Team.Enemy) { }
    }
    internal class CharacterClasses : Character
    {
        public override string Name => "THE UNCODED ONE";
        public override IAttack BasicAttack => new UnravellAttack();
        public CharacterClasses() : base(15, Team.Enemy) { }
    }
}

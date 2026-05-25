namespace TheCoreBattle
{
    public abstract class Modifier
    {
        public abstract string Name { get; }
        public abstract int Value { get; }
        public AttackResult ReduceAttack(AttackResult attackResult)
        {
            Console.WriteLine($"{Name} reduced the damage by {Value}");
            return new AttackResult(attackResult.Damage - Value);
        }
    }
    public class StoneArmor : Modifier
    {
        public override string Name => "Stone Armor";
        public override int Value => 1;
    }
}

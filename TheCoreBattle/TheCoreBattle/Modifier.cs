namespace TheCoreBattle
{
    public abstract class Modifier
    {
        public abstract string Name { get; }
        public abstract int Value { get; }
        public virtual AttackResult ReduceAttack(AttackResult attackResult)
        {
            Console.WriteLine($"{Name} reduced the damage by {Value}");
            return new AttackResult(Math.Clamp(attackResult.Damage - Value,0,attackResult.Damage), attackResult.damageType);
        }
    }
    public class StoneArmor : Modifier
    {
        public override string Name => "Stone Armor";
        public override int Value => 1;
    }
    public class ObjectSight : Modifier
    {
        public override string Name => "Object Sight";
        public override int Value => 2; 
        public override AttackResult ReduceAttack(AttackResult attackResult)
        {
            if (attackResult.damageType == DamageType.Decoding)
            {
                Console.WriteLine($"{Name} reduced the damage by {Value}");
                return new AttackResult(Math.Clamp(attackResult.Damage - Value, 0, attackResult.Damage), attackResult.damageType);
            }
            else
                return attackResult;
        }
    }
}

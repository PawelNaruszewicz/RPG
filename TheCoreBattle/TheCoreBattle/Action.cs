
namespace TheCoreBattle
{
    public interface IAttack
    {
        abstract string Name { get; }
        abstract int DamageValue { get; set; }
    }
}

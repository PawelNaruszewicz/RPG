

namespace TheCoreBattle
{
    public abstract class ConsumableItem
    {
        public abstract string Name { get; }
        public abstract void UseItem(Character character);
    }
    public class Potion : ConsumableItem
    {
        public int healthValue { get; }
        public override string Name => "Health Potion";
        public Potion()
        {
            healthValue = 10;
        }
        public override void UseItem(Character character)
        {
            character.CurrentHealth = character.CurrentHealth + healthValue;
        }
    }
}


namespace TheCoreBattle
{
    public interface IAttack
    {
        string Name { get; }
        AttackResult GetAttackDamage();
    }
    public interface IAction
    {
        void Run(Character character, Character target, ChatDisplay chatDisplay);
    }
    public interface IDoNothingAction
    {
        void Run(Character character);
    }
    public interface ISingleCharacterActionWithItem
    {
        void Run(Character character, ConsumableItem item);
    }

    public class GearInteraction
    {
        public void ManipulateItems(Character character, Player player, Item item)
        {
            player.ItemManager.ManipulateEquippedItem(character, item);
        }
    }
    public class DoNothing : IDoNothingAction
    {
        public void Run(Character character)
        {
            Console.WriteLine($"{character.Name} did NOTHING");
        }
    }
    public class UsePotion : ISingleCharacterActionWithItem
    {
        public void Run(Character character, ConsumableItem item)
        {
            item.UseItem(character);
            Console.WriteLine($"{character.Name} used {item.Name}!");
            Console.WriteLine($"{character.Name} healh is {character.CurrentHealth}/ {character.MaxHealth}");
        }
    }
    public class GearAttack : IAction
    {
        public void Run(Character character, Character target, ChatDisplay chatDisplay)
        {
            AttackResult attackData = character.ItemEquipped.Attack.GetAttackDamage();
            target.CurrentHealth = target.CurrentHealth - attackData.Damage;

            chatDisplay.DisplayWeaponAttack(character, target, attackData);

        }
    }
    public class BasicAction : IAction
    {
        public void Run(Character character, Character target, ChatDisplay chatDisplay)
        {
                AttackResult attackData = character.BasicAttack.GetAttackDamage();
                target.CurrentHealth = target.CurrentHealth - attackData.Damage;

                chatDisplay.DisplayBasicAttack(character, target, attackData);

        }
    }
    public record AttackResult(int Damage);
}


namespace TheCoreBattle
{
    public interface IAttack
    {
        string Name { get; }
        AttackResult GetAttackDamage();
    }
    public interface IAction
    {
        void Run(Character character, Character target);
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
    public class GearAttack : IAction
    {
        public void Run(Character character, Character target)
        {
            AttackResult attackData = character.ItemEquipped.Attack.GetAttackDamage();
            target.CurrentHealth = target.CurrentHealth - attackData.Damage;
            // TODO DOADĆ MOŻE CHAT KTÓRY DISPLAYUJE TO WSZYSTKO?
            // TYPU PASSUJEMY MU CHARACTER, TARGET, TYP ATTACKU I ON Z TEGO SKLEJA TEKST?
            Console.WriteLine($"{character.Name} used {character.ItemEquipped.Name} on {target.Name}");
            Console.WriteLine($"{character.ItemEquipped.Name} dealt {attackData.Damage} to {target.Name}");
            Console.WriteLine($"{target.Name} is at {target.CurrentHealth} / {target.MaxHealth} HP");
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
    public class BasicAction : IAction
    {
        public void Run(Character character, Character target)
        {
            AttackResult attackData = character.BasicAttack.GetAttackDamage();

            target.CurrentHealth = target.CurrentHealth - attackData.Damage;
            Console.WriteLine($"{character.Name} used {character.BasicAttack.Name} on {target.Name}");
            Console.WriteLine($"{character.BasicAttack.Name} dealt {attackData.Damage} to {target.Name}");
            Console.WriteLine($"{target.Name} is at {target.CurrentHealth} / {target.MaxHealth} HP");
        }
    }
    public record AttackResult(int Damage);
}

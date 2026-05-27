
namespace TheCoreBattle
{
    public interface IAttack
    {
        string Name { get; }
        AttackResult GetAttackDamage();
        HitAccuracy GetHitChance();
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

    public class ItemInteractions
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
            if (character.ItemEquipped == null) return;
            AttackResult attackData = character.ItemEquipped.Attack.GetAttackDamage();
            HitAccuracy hitChance = character.ItemEquipped.Attack.GetHitChance();

            if (target.Modifier != null)
            {
                attackData = target.Modifier.ReduceAttack(attackData);
            }

            if (Random.Shared.NextDouble() > hitChance.chanceToHit)
            {
                chatDisplay.DisplayMissedAttack(character, target);
            }
            else
            {
                target.CurrentHealth = target.CurrentHealth - attackData.Damage;
                chatDisplay.DisplayWeaponAttack(character, target, attackData);
            }
        }
    }
    public class BasicAction : IAction
    {
        public void Run(Character character, Character target, ChatDisplay chatDisplay)
        {
            AttackResult attackData = character.BasicAttack.GetAttackDamage();
            
            if(target.Modifier!= null)
            {
                attackData = target.Modifier.ReduceAttack(attackData);
            }

            target.CurrentHealth = target.CurrentHealth - attackData.Damage;
            chatDisplay.DisplayBasicAttack(character, target, attackData);

        }
    }
    public record AttackResult(int Damage);
    public record HitAccuracy(float chanceToHit);
}

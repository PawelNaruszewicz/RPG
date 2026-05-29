
namespace TheCoreBattle
{
    public interface IAttack
    {
        string Name { get; }
        float HitChance { get; }
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
    public interface IBattleAction
    {
        void Execute(BattleContext context);
    }
    public class BasicAttackAction : IBattleAction
    {
        public void Execute(BattleContext context)
        {
            AttackResult attackData = context.CurrentCharacter.BasicAttack.GetAttackDamage();

            if (context.Target.Modifier != null)
            {
                attackData = context.Target.Modifier.ReduceAttack(attackData);
            }

            context.Target.CurrentHealth = context.Target.CurrentHealth - attackData.Damage;
            context.ChatDisplay.DisplayBasicAttack(context.CurrentCharacter, context.Target, attackData);
        }
    }

    public class UsePotionAction : IBattleAction
    {
        public void Execute(BattleContext context)
        {
            context.CurrentPlayer.ItemManager.PartyConsumableItems[0].UseItem(context.CurrentCharacter);
            Console.WriteLine($"{context.CurrentCharacter.Name} used {context.CurrentCharacter.Name}!");
            Console.WriteLine($"{context.CurrentCharacter.Name} healh is {context.CurrentCharacter.CurrentHealth}/ {context.CurrentCharacter.MaxHealth}");
        }
    }
    public class EquipItemAction : IBattleAction
    {
        public void Execute(BattleContext context)
        {
            while (true)
            {
                Console.WriteLine("Pick which item do you want to equip?");
                context.CurrentPlayer.ItemManager.DisplayCurrentItems();

                string input = "";
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result >= 0 && result < context.CurrentPlayer.ItemManager.PartyItems.Count)
                    {
                        context.CurrentCharacter.CharacterActions.EquipItems.ManipulateItems(context.CurrentCharacter, context.CurrentPlayer, context.CurrentPlayer.ItemManager.GetItemByID(result));
                        break;
                    }
                }
            }
        }
        private void DecideWhichItemToEquip(BattleContext context)
        {

        }
    }
    public class ItemInteractions
    {
        public void ManipulateItems(Character character, Player player, Item item)
        {
            player.ItemManager.ManipulateEquippedItem(character, item);
        }
    }
    public class DoNothing : IBattleAction
    {
        public void Execute(BattleContext context)
        {
            Console.WriteLine($"{context.CurrentCharacter.Name} did NOTHING");
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
    public class GearAttack : IBattleAction
    {
        public void Execute(BattleContext context)
        {
            if (context.CurrentCharacter.ItemEquipped == null) return;
            AttackResult attackData = context.CurrentCharacter.ItemEquipped.Attack.GetAttackDamage();
            float hitChance = context.CurrentCharacter.ItemEquipped.Attack.HitChance;

            if (context.Target.Modifier != null)
            {
                attackData = context.Target.Modifier.ReduceAttack(attackData);
            }

            if (Random.Shared.NextDouble() > hitChance)
            {
                context.ChatDisplay.DisplayMissedAttack(context.CurrentCharacter, context.Target);
            }
            else
            {
                context.Target.CurrentHealth = context.Target.CurrentHealth - attackData.Damage;
                context.ChatDisplay.DisplayWeaponAttack(context.CurrentCharacter, context.Target, attackData);
            }
        }
    }
    //public class BasicAction : IAction
    //{
    //    public void Run(Character character, Character target, ChatDisplay chatDisplay)
    //    {
    //        AttackResult attackData = character.BasicAttack.GetAttackDamage();

    //        if (target.Modifier != null)
    //        {
    //            attackData = target.Modifier.ReduceAttack(attackData);
    //        }

    //        target.CurrentHealth = target.CurrentHealth - attackData.Damage;
    //        chatDisplay.DisplayBasicAttack(character, target, attackData);

    //    }
    //}
    public record AttackResult(int Damage, DamageType damageType);
    public enum DamageType { Normal, Decoding }
}


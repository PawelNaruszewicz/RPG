
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
        //NOT SURE CZY TRZEBA TUTAJ PLAYERA
        void Run(Character character, Item item, Player player);
    }

    public class EquipGear
    {
        public void Run(Character character, Player player)
        {
            //TO DO DODAĆ ZDEJMOWANIE ITEMÓW
            character.GearEquipped = player.partyGear[0];
            player.partyGear.Remove(player.partyGear[0]);
            character.HasGearEquipped = true;
        }
    }
    public class GearAction
    {
        public void Run(Character character, Character target)
        {
            AttackResult attackData = character.GearEquipped.Attack.GetAttackDamage();
            target.CurrentHealth = target.CurrentHealth - attackData.Damage;
            // TO DO DOADĆ MOŻE CHAT KTÓRY DISPLAYUJE TO WSZYSTKO?
            // TYPU PASSUJEMY MU CHARACTER, TARGET, TYP ATTACKU I ON Z TEGO SKLEJA TEKST?
            Console.WriteLine($"{character.Name} used {character.GearEquipped.Name} on {target.Name}");
            Console.WriteLine($"{character.GearEquipped.Name} dealt {attackData.Damage} to {target.Name}");
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
        public void Run(Character character, Item item, Player player)
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

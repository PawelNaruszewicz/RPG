
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
    public class BasicAction: IAction
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

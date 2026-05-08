
namespace TheCoreBattle
{
    public interface IAttack
    {
        string Name { get; }
        int DamageValue { get; }
}
    public interface IAction
    {
        void Run(GameManager gameManager, Character character);
    }
    public class DoNothing : IAction
    {
        public void Run(GameManager gameManager, Character character)
        {
            Console.Write($"{character.Name} did NOTHING");
            Console.WriteLine("DEBUG");
        }
    }
    public class UseAction: IAction
    {
        public void Run(GameManager gameManager, Character character)
        {
            Console.Write($"{character} used {character.BasicAttack} on ...");

        }
    }
}

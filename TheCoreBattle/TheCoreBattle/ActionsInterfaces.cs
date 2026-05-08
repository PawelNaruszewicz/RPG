
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
            Console.Write($"{character} did NOTHING");
        }
    }
    public class UseAction: IAction
    {
        public void Run(GameManager gameManager, Character character)
        {
            Console.Write($"{character} used ");
        }
    }
}

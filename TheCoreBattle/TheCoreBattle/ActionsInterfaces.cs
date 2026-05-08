
namespace TheCoreBattle
{
    public interface IAttack
    {
        string Name { get; }
        AttackResult Create();
        //int DamageValue { get; }
    }
    public interface IAction
    {
        void Run(GameManager gameManager, Character character);
    }
    public class DoNothing : IAction
    {
        public void Run(GameManager gameManager, Character character)
        {
            Console.WriteLine($"{character.Name} did NOTHING");
        }
    }
    public class UseAction: IAction
    {
        Character character;
        Character target;
        public void Run(GameManager gameManager, Character character)
        {
            AttackResult attackData = character.BasicAttack.Create();

            Console.WriteLine($"{character.Name} used {character.BasicAttack.Name} on {gameManager.OppositePlayer.myCharacterList[0].Name}");
            Console.WriteLine($"{character.BasicAttack.Name} dealt {attackData.Damage} to {gameManager.OppositePlayer.myCharacterList[0].Name}");
            Console.WriteLine($"{gameManager.OppositePlayer.myCharacterList[0].Name} is at {gameManager.OppositePlayer.myCharacterList[0].CurrentHealth} / {gameManager.OppositePlayer.myCharacterList[0].MaxHealth} HP");
        }
    }
    public record AttackResult(int Damage);
}

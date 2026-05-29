
namespace TheCoreBattle
{
    public class BattleContext
    {
        public Character CurrentCharacter { get; init; }
        public Character Target { get; init; }

        public Player CurrentPlayer { get; init; }
        public Player OppositePlayer { get; init; }

        public ChatDisplay ChatDisplay { get; init; }

        public GameManager GameManager { get; init; }
    }
}

namespace TheCoreBattle
{
    public class GameMode
    {
        public GameModeType CurrentGameMode { get; }
        public GameMode(GameModeType gameMode)
        {
            CurrentGameMode = gameMode;
        }
    }
    public enum GameModeType { PlayerVsPc, PcVsPc, PlayerVsPlayer }
}

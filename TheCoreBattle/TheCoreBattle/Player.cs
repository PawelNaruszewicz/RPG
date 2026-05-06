namespace TheCoreBattle
{
    internal class Player
    {
        public List<Character> myCharacterList { get; set; }
        public Team Team { get; set; }

        public Player(Team team)
        {
            myCharacterList = new List<Character>();
            Team = team;
        }
        public void AddCharacterToMyTeam(Character character)
        {
            character.Team = Team;
            myCharacterList.Add(character);
        }
    }
    public enum Team { Player, Enemy }

}

namespace TheCoreBattle
{
    public class Player
    {
        public List<Character> myCharacterList { get; set; }
        public Team Team { get; }
        public bool IsHuman {get;}

        public Player(Team team, bool isHuman)
        {
            myCharacterList = new List<Character>();
            Team = team;
            IsHuman = isHuman;
        }
        public void AddCharacterToMyTeam(Character character)
        {
            character.Team = Team;
            myCharacterList.Add(character);
        }
        public void CharacterDied(Character characterToRemove)
        {
            myCharacterList.Remove(characterToRemove);
        }
    }
    public enum Team { Player, Enemy }

}

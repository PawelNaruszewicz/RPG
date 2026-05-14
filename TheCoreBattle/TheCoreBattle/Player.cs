namespace TheCoreBattle
{
    public class Player
    {
        public List<Character> myCharacterList { get; set; }
        public List<Item> partyItems { get; set; }
        public Team Team { get; }
        public bool IsHuman {get;}

        public Player(Team team, bool isHuman)
        {
            myCharacterList = new List<Character>();
            partyItems = new List<Item>();
            Team = team;
            IsHuman = isHuman;
        }
        public void AddItemsToMyTeam(Item item)
        {
            partyItems.Add(item);
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

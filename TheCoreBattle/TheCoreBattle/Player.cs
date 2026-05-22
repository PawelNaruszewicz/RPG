namespace TheCoreBattle
{
    public class Player
    {
        public List<Character> myCharacterList { get; set; }
        public Team Team { get; }
        public bool IsHuman { get; }
        public ItemManager ItemManager { get; private set; } = new ItemManager();
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
            if (characterToRemove.HasGearEquipped()) ItemManager.ManipulateEquippedItem(characterToRemove, characterToRemove.ItemEquipped);
            myCharacterList.Remove(characterToRemove);
        }
    }
    public enum Team { Player, Enemy }

}

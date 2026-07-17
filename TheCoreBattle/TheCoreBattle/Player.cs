namespace TheCoreBattle
{
    public class Player
    {
        public List<Character> MyCharacterList { get; set; }
        public Team Team { get; }
        public bool IsHuman { get; }
        public ItemManager ItemManager { get; private set; } = new ItemManager();
        public Player(Team team, bool isHuman)
        {
            MyCharacterList = new List<Character>();

            Team = team;
            IsHuman = isHuman;
        }

        public void AddCharacterToMyTeam(Character character)
        {
            character.Team = Team;
            MyCharacterList.Add(character);
        }
        public void CharacterDied(Character characterToRemove)
        {
            if (characterToRemove.HasGearEquipped()) ItemManager.ManipulateEquippedItem(characterToRemove, characterToRemove.ItemEquipped);
            MyCharacterList.Remove(characterToRemove);
        }
        public void DisplayAllTeamCharacters()
        {
            for(int i = 0; i <MyCharacterList.Count; i++)
            {
                Console.WriteLine($"{i} - {MyCharacterList[i].Name}");
            }
        }
    }
    public enum Team { Player, Enemy }

}


namespace TheCoreBattle
{
    internal class Character
    {
        public string Name { get; set; }
        public Team Team { get; set; }

        public Character(string name, Team team)
        {
            Name = name;
            Team = team;
        }
        public override string ToString()
        {
            return ($"Name is {Name}, Team is {Team}");
        }
    }
    public enum Team { Player, Enemy}
}

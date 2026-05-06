
namespace TheCoreBattle
{
    internal class Character
    {
        public string Name { get; set; }
        public Team Team;

        public Character(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return ($"Name is {Name}");
        }
    }
}

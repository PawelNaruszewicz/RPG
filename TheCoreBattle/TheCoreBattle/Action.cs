
namespace TheCoreBattle
{
    internal class Action
    {
        public string Name { get; set; }
        public int DamageValue { get; set; }
        public Action(string name)
        {
            Name = name;
        }
    }
}

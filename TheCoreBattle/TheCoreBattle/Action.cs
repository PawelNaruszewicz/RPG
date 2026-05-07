
namespace TheCoreBattle
{
    internal class Action
    {
        public string Name { get; set; }
        public int DamageValue { get; set; }
        private Random random = new Random();
        public Action(string name)
        {
            Name = name;

        }
        public void DealDamage(Character character)
        {
            this.DamageValue = Name switch
            {
                "PUNCH" => 1,
                "BONE CRUNCH" => random.Next(2)
            };

            character.CurrentHealth -= this.DamageValue;
        }
    }
}

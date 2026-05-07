namespace TheCoreBattle
{
    public class Nothing : IAttack
    {
        public void Attack(Character character)
        {
            Console.WriteLine($"{character} did NOTHING");
        }
    }
    public class BasicAttack : IAttack
    {
        public void Attack(Character character)
        {

        }
    }
    public class Punch : IAttack
    {
        public string Name = "PUNCH";
        public int DamageValue = 1;
    }
}

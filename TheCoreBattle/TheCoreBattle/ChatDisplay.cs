
namespace TheCoreBattle
{
    internal class ChatDisplay
    {
        public void DisplayChat(Character character)
        {
            DisplayTurn(character);
            DisplayAction(character);
        }
        private void DisplayTurn(Character character)
        {
            Console.WriteLine($"It is {character.Name} turn...");
        }
        private void DisplayAction(Character character)
        {
            Console.WriteLine($"{character.Name} did NOTHING\n");
        }
    }
}

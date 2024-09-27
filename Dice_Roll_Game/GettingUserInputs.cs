namespace Dice_Roll_Game
{
    public class GettingUserInputs
    {
        public static int GetUserInput(string message)
        {
            int userInput;
            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("\nInvalid Input.Enter only numbers");
                Console.Write(message);
            }
            return userInput;
        }
    }
}

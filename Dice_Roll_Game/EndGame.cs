namespace Dice_Roll_Game
{
    public class EndGame
    {
        public static void IsGameEnd(bool result)
        {
            string message = result == true ? "\nYou Win !!!\nPress any key to close window" : "\nYou lose ;(\nPress any key to close window";

            Console.WriteLine(message);
        }
    }
    

}

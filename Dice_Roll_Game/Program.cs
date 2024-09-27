namespace Dice_Roll_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dice = new Dice();
            StartGame newGame = new StartGame(dice);
            newGame.PlayGame();
            Console.ReadLine();
        }
    }
}

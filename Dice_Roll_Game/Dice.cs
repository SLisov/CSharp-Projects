namespace Dice_Roll_Game
{
    public class Dice
    {
        private const int DiceSides = 6;

        public int GetRandomDiceNumber()
        {
            return new Random().Next(1, DiceSides + 1);
        }
    }

}

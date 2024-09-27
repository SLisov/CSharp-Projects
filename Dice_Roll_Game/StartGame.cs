namespace Dice_Roll_Game
{
    public class StartGame
    {
        private readonly Dice _dice;
        private const int InitialTries = 3;

        public StartGame(Dice dice)
        {
            _dice = dice;
        }

        public void PlayGame()
        {
            int diceNumber = _dice.GetRandomDiceNumber();
            int triesLeft = InitialTries;
            int userInput;
            string message = "\nEnter a number:  ";

            Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");

            while (triesLeft > 0)
            {
                userInput = GettingUserInputs.GetUserInput(message);

                if (userInput == diceNumber)
                {
                    EndGame.IsGameEnd(true);
                    return;
                }

                Console.WriteLine("\nWrong number");
                --triesLeft;
            }
            EndGame.IsGameEnd(false);
        } 
    }
}

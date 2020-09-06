using System;

namespace GridGame {

    public class Program {

        private static int gridMin = 3;
        private static int gridMax = 10;

        public static int GetIntInput(string message) {
            bool valid;
            int intRes;

            do {
                Console.WriteLine(message);

                string input = Console.ReadLine();
                valid = int.TryParse(input, out intRes);

                if (!valid) {
                    Console.WriteLine("Input must be an integer.");
                }
            } while (!valid);

            return intRes;
        }

        public static int GetIntInputInRange(string message, int min, int max) {
            bool valid;
            int intRes;

            do {
                intRes = GetIntInput(message);
                valid = intRes >= min && intRes <= max;

                if (!valid) {
                    Console.WriteLine($"Input must be in the range from {min} to {max}.");
                }
            } while (!valid);

            return intRes;
        }

        public static void Main() {
            int gridSize = GetIntInputInRange("What size should the grid be?", gridMin, gridMax);

            GameController gameController = new GameController(gridSize);

            bool foundTarget = false;

            do {
                int guessX = GetIntInputInRange("Enter X co-ordinate guess:", 0, gridSize-1);
                int guessY = GetIntInputInRange("Enter Y co-ordinate guess:", 0, gridSize-1);
                int guessZ = GetIntInputInRange("Enter Z co-ordinate guess:", 0, gridSize-1);

                Point3D guess = new Point3D(guessX, guessY, guessZ);
                GuessResult guessRes = gameController.MakeGuess(guess);

                if (guessRes == GuessResult.Hit) {
                    foundTarget = true;
                } else if (guessRes == GuessResult.Miss) {
                    Point3D offset = gameController.GetGuessOffsetAsPoint(guess);

                    string resX = offset.x == 0 ? "correct" : offset.x < 0 ? "too high" : $"too low";
                    string resY = offset.y == 0 ? "correct" : offset.y < 0 ? "too high" : $"too low";
                    string resZ = offset.z == 0 ? "correct" : offset.z < 0 ? "too high" : $"too low";

                    Console.WriteLine("Your guess missed the target.");
                    Console.WriteLine($"Your X is {resX}, your Y is {resY} and your Z is {resZ}.");

                    gameController.MoveTarget();
                } else if (guessRes == GuessResult.OutOfRange) {
                    Console.WriteLine("Your guess was out of the grid's range.");
                }
            } while (!foundTarget);

            int totalGuesses = gameController.guesses;

            Console.WriteLine($"You found the target after {totalGuesses} guesses!");
        }

    }

}

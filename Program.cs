using System;

namespace GridGame {
    class Program {

        static void Main(string[] args) {
            int gridMin = 3;
            int gridMax = 10;

            int gridSize;

            while (true) {
                Console.WriteLine("What size should the grid be? (3-10)");

                string gridInput = Console.ReadLine();

                try {
                    // Convert grid input to integer
                    gridSize = Convert.ToInt32(gridInput);

                    // Exit loop if in bounds
                    if (gridSize >= gridMin && gridSize <= gridMax) {
                        break;
                    } else {
                        Console.WriteLine("Grid size must be in the range 3 to 10.");
                    }
                } catch {
                    Console.WriteLine("Grid size must be an integer.");
                }
            }

            Random rand = new Random();
            int randX = rand.Next(0, gridSize); // min inclusive, max exclusive
            int randY = rand.Next(0, gridSize);
            int randZ = rand.Next(0, gridSize);

            int guesses = 0;

            while (true) {
                Console.Write("Enter X co-ordinate: ");
                string xInput = Console.ReadLine();

                Console.Write("Enter Y co-ordinate: ");
                string yInput = Console.ReadLine();

                Console.Write("Enter Z co-ordinate: ");
                string zInput = Console.ReadLine();

                try {
                    // Convert guess to integers
                    int xGuess = Convert.ToInt32(xInput);
                    int yGuess = Convert.ToInt32(yInput);
                    int zGuess = Convert.ToInt32(zInput);

                    // Don't count guesses out of range
                    if (xGuess < 0 || yGuess < 0 || zGuess < 0 || xGuess >= gridSize || yGuess >= gridSize || zGuess >= gridSize) {
                        Console.WriteLine("Your guess was out of the grid's range.");

                        continue;
                    }

                    guesses++; // Increase guess count AFTER validating input

                    // Exit loop if correct
                    if (xGuess == randX && yGuess == randY && zGuess == randZ) {
                        break;
                    }

                    string responseString = "Your X is ";

                    // X result
                    if (xGuess == randX) {
                        responseString += "correct";
                    } else if (xGuess > randX) {
                        responseString += "too high";
                    } else {
                        responseString += "too low";
                    }

                    responseString += ", your Y is ";

                    // Y result
                    if (yGuess == randY) {
                        responseString += "correct";
                    } else if (yGuess > randY) {
                        responseString += "too high";
                    } else {
                        responseString += "too low";
                    }

                    responseString += ", your Z is ";

                    // Z result
                    if (zGuess == randZ) {
                        responseString += "correct";
                    } else if (zGuess > randZ) {
                        responseString += "too high";
                    } else {
                        responseString += "too low";
                    }

                    Console.WriteLine(responseString+".");
                } catch { // If guess is not of integer values
                    Console.WriteLine("Co-ordinates must be integers.");
                }
            }

            Console.WriteLine("You found the target at "+randX+", "+randY+", "+randZ+"!");
            Console.WriteLine("It took you " + guesses + " guesses to find the target.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string playAgain = "";

            do
            {
                Random randomNumber = new Random();
                int numberOfNumber = 6;
                int jackpot = 55000;
                int correctNumbers = 0;
                
               
                // Ask the user for a starting number for the lowest number in the number range.
                Console.WriteLine("Please enter the lowest possible number.");
                int startingNumber = int.Parse(Console.ReadLine());

                // Ask the user for an ending number for the highest number in the number range.
                Console.WriteLine("please enter the highest possible number.");
                int endingNumber = int.Parse(Console.ReadLine());

                // Ask the user to guess the 6 numbers the user thinks will be the lucky numbers generated within the number range.
                int[] guessNumbers = new int[numberOfNumber];
                for (int i = 0; i < guessNumbers.Length; i++)
                {

                    Console.WriteLine("Please enter the your numbers one at a time.");
                    guessNumbers[i] = int.Parse(Console.ReadLine());

                    while (guessNumbers[i] < startingNumber || guessNumbers[i] > endingNumber)
                    {
                        Console.WriteLine("Please enter a number inbetween {0}-{1}", startingNumber, endingNumber);
                        guessNumbers[i] = int.Parse(Console.ReadLine());
                    }
                }
                // The program should randomly generate 6 numbers using a loop
                // The randomly generated numbers should be stored in an array

                int[] luckyNumbers = new int[numberOfNumber];

                for (int i = 0; i < luckyNumbers.Length; i++)
                {
                    luckyNumbers[i] = randomNumber.Next(startingNumber, endingNumber + 1);
                }

                Array.Sort(guessNumbers);
                Array.Sort(luckyNumbers);

                for (int i = 0; i < numberOfNumber; i++)
                {
                    Console.WriteLine("Lucky Number:{0}\tYour Number:{1}", luckyNumbers[i], guessNumbers[i]);
                }

                for (int i = 0; i < guessNumbers.Length; i++)
                {
                    foreach (int number in guessNumbers)
                        if (number == luckyNumbers[i])
                        {
                            correctNumbers += 1;
                        }
                }
                Console.WriteLine("Congrats you guessed {0} numbers correctly!!!", correctNumbers);

                if (correctNumbers == 6)
                {
                    Console.WriteLine("You have done the impossible you have won ${0}!!!!!!", jackpot * 1);
                }

                else if (correctNumbers >= 4)
                {
                    Console.WriteLine("You did amazing you have won ${0}!!!", jackpot * .7);
                }

                else if (correctNumbers >= 2)
                {
                    Console.WriteLine("You did pretty good...You have won ${0}!!", jackpot * .25);
                }

                else if (correctNumbers == 1)
                {
                    Console.WriteLine("Eh, you got one not too bad I guess. As a consolation you have won ${0}.", jackpot * .05);
                }
                else
                {
                    Console.WriteLine("Better luck next time!!!");
                }

                Console.WriteLine("\n\n\nWould you like to play again? YES/NO");
                playAgain = Console.ReadLine();
                while (playAgain != "yes")
                {
                    Console.WriteLine("Thanks for playing!");
                    Console.WriteLine("Did you change your mind? YES/NO");
                    playAgain = Console.ReadLine();
                }
            }
            while (playAgain == "yes");
                
                // Make your program ensure none of the generated numbers are repeated.For example, the following is a valid output:
                //            Lucky Number: 12
                //Lucky Number: 47
                //Lucky Number: 28
                //Lucky Number: 3
                //Lucky Number: 19
                //Lucky Number: 35
                //But, the following output is invalid because 12 is generated twice.
                //Lucky Number: 12
                //Lucky Number: 47
                //Lucky Number: 28
                //Lucky Number: 3
                //Lucky Number: 19
                //Lucky Number: 12
                //If there is a repeated number, replace it with a new number.Do this until there are no repeated numbers.










            }
    }
    }

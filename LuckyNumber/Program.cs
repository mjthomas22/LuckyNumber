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
                int dupCheck = 0;

                Console.WriteLine("Welcome to the greatest guessing game in the history of games!\n");
                Console.WriteLine("You can win up to ${0} if you can get all {1} numbers right!\n", jackpot, numberOfNumber);
                // Ask the user for a starting number for the lowest number in the number range.
                Console.WriteLine("Please enter a low number that is 0 or higher.");
                int startingNumber = int.Parse(Console.ReadLine());

                while (startingNumber < 0)
                {
                    Console.WriteLine("\nPlease enter a number that is higher than 0!");
                    startingNumber = int.Parse(Console.ReadLine());
                }


                // Ask the user for an ending number for the highest number in the number range.
                Console.WriteLine("\nPlease enter a higher number.");
                int endingNumber = int.Parse(Console.ReadLine());

                // Ask the user to guess the 6 numbers the user thinks will be the lucky numbers generated within the number range.
                int[] guessNumbers = new int[numberOfNumber];
                for (int i = 0; i < guessNumbers.Length; i++)
                {

                    Console.WriteLine("\nPlease enter {0} numbers one at a time. These will be your {0} numbers to match our \"Lucky Numbers\"", numberOfNumber);
                    dupCheck = int.Parse(Console.ReadLine());

                    while (dupCheck < startingNumber || dupCheck > endingNumber)
                    {
                        Console.WriteLine("\nPlease enter a number inbetween {0}-{1}", startingNumber, endingNumber);
                        dupCheck = int.Parse(Console.ReadLine());
                    }

                    while (guessNumbers.Contains(dupCheck))
                    {
                        Console.WriteLine("\nPlease enter a number you have not already entered.");
                        dupCheck = int.Parse(Console.ReadLine());

                        while (dupCheck < startingNumber || dupCheck > endingNumber)
                        {
                            Console.WriteLine("\nPlease enter a number inbetween {0}-{1}", startingNumber, endingNumber);
                            dupCheck = int.Parse(Console.ReadLine());
                        }

                    }
                    guessNumbers[i] = dupCheck;


                }
                // The program should randomly generate 6 numbers using a loop
                // The randomly generated numbers should be stored in an array

                int[] luckyNumbers = new int[numberOfNumber];


                for (int i = 0; i < luckyNumbers.Length; i++)
                {
                    do
                    {
                        dupCheck = randomNumber.Next(startingNumber, endingNumber + 1);
                    }
                    while (luckyNumbers.Contains(dupCheck));
                    luckyNumbers[i] = dupCheck;
                }

                Array.Sort(guessNumbers);
                Array.Sort(luckyNumbers);

                for (int i = 0; i < numberOfNumber; i++)
                {
                    Console.WriteLine("\nLucky Number:{0}\t\t\tYour Number:{1}", luckyNumbers[i], guessNumbers[i]);
                }

                for (int i = 0; i < guessNumbers.Length; i++)
                {
                    foreach (int number in luckyNumbers)
                    {
                        if (number == guessNumbers[i])
                        {
                            correctNumbers += 1;
                        }
                    }
                }
                Console.WriteLine("\nYou guessed {0} numbers correctly!!!", correctNumbers);

                if (correctNumbers == 6)
                {
                    Console.WriteLine("\nYou have done the impossible you have won ${0}!!!!!!", jackpot * 1);
                }

                else if (correctNumbers >= 4)
                {
                    Console.WriteLine("\nYou did amazing you have won ${0}!!!", jackpot * .7);
                }

                else if (correctNumbers >= 2)
                {
                    Console.WriteLine("\nYou did pretty good...You have won ${0}!!", jackpot * .25);
                }

                else if (correctNumbers == 1)
                {
                    Console.WriteLine("\nEh, you got one not too bad I guess. As a consolation you have won ${0}.", jackpot * .05);
                }
                else
                {
                    Console.WriteLine("\nBetter luck next time!!!");
                }

                Console.WriteLine("\nWould you like to play again? YES/NO");
                playAgain = Console.ReadLine();
                while (playAgain != "yes")
                {
                    Console.WriteLine("\nThanks for playing!");
                    Console.WriteLine("\nDid you change your mind? YES/NO/QUIT");
                    playAgain = Console.ReadLine();

                    if (playAgain.ToLower() == "quit")
                    {
                        break;
                    }
                }
            }
            while (playAgain == "yes");







        }
    }
}

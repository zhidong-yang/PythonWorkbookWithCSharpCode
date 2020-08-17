﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonWorkbookInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadLine();
        }

        //##################### START OF EXERCISE 11 FUEL EFFICIENCY ################################
        public static void MPGToLPH(double mpg)
        {
            // 1 mile = 1.6km
            // 1 gallon = 3.79 liters
            // 1hpl = 1000km/1L = (1000/1.6)mile / (1/3.79)gallon
            // 1LPH = 1/1hpl

            double LPH = 1 / (mpg / ((1000 / 1.6) / (1 / 3.79)));
        }
        //##################### END OF EXERCISE 11 FUEL EFFICIENCY ###################################


        //##################### START OF EXERCISE 48 CHINESE ZODIAC ################################
        public static void ChineseZodiac(int year)
        {
            //2000 % 12 = 8, which makes year 0 Year Monkey.
            int yearResidual = year % 12;
            switch (yearResidual)
            {
                case 0:
                    {
                        Console.WriteLine("Monkey");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Rooster");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Dog");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Pig");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Rat");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Ox");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Tiger");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Hare");
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Dragon");
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("Snake");
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("Horse");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Sheep");
                        break;
                    }
            }

        }

        //##################### END OF EXERCISE 48 CHINESE ZODIAC ###################################


        //##################### START OF EXERCISE 64 NO MORE PENNIES ################################
        public static void PennyLessPay()
        {
            
            double sum = 0.00;
            Console.Write("What is the price (press Enter to finish): ");
            string userInput = Console.ReadLine();

            while (!String.IsNullOrEmpty(userInput))
            {
                // assumption: the user enters non-negative number
                double priceReading = Math.Round(Convert.ToDouble(userInput),2,MidpointRounding.AwayFromZero);
                sum += priceReading;

                Console.Write("What is the price (press Enter to finish): ");
                userInput = Console.ReadLine();
            }

            double pennylessTotal = sum;
            if ((sum*100) % 5 != 0)
            {
                if ((sum * 100) % 5 > 2) // round up for total price more than 0.05 precision
                {
                    pennylessTotal = ((pennylessTotal * 100) + (5 - (sum * 100) % 5)) / 100;  
                }
                else // round down for price less than 0.05 precision
                {
                    pennylessTotal = ((pennylessTotal * 100) - ((sum * 100) % 5)) / 100;
                }
            }

            Console.WriteLine($"The total price is {sum}");
            Console.WriteLine($"The actual pennyless balance is {pennylessTotal}");
        }

        //##################### END OF EXERCISE 64 NO MORE PENNIES ###################################


        //##################### START OF EXERCISE 69 APPROXIMATE PAI ################################
        public static void ApproxPai(int num)
        {
            // num is how many approximation of pai desired. In original question it requires to display all 15
            // Here I display only one based on input
            double outupt = 3.0;
            for (int i = 1; i < num; i++)
            {
                if (i % 2 != 0)
                {
                    outupt += (4 / ((2 * i) * (2 * (i + 1)) * (2 * (i + 2))));
                }
                else
                {
                    outupt -= (4 / ((2 * i) * (2 * (i + 1)) * (2 * (i + 2))));
                }
            }

            Console.WriteLine($"The {num}th approximation of Pai is {outupt}.");
        }

        //##################### END OF EXERCISE 69 APPROXIMATE PAI ###################################


        //##################### START OF EXERCISE 70 CAESAR CYPHER ################################
        public static string CaesarCypher(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    int charNum = (int)input[i];
                    // X = 88 --> A = 65; x = 120 --> a = 97
                    if ((charNum > 87 && charNum < 91) || (charNum > 129 && charNum < 123))
                    {
                        input = input.Replace(input[i], (char)(charNum - 23));
                    }
                    else
                    {
                        input = input.Replace(input[i], (char)(charNum + 3));
                    }
                }                
            }

            return input;
        }

        //##################### END OF EXERCISE 70 CAESAR CYPHER ###################################



        //##################### START OF EXERCISE 72 STRING PALINDROME ################################
        public static void StringPalindrome(string input)
        {
            bool output = true;

            int start = 0;
            int end = input.Length - 1;
            while (start < end)
            {
                if (input[start] != input[end])
                {
                    output = false;
                    break;
                }
                start++;
                end--;
            }

            Console.WriteLine($"It is {output} that {input} is a palindrome.");
        }

        //##################### END OF EXERCISE 72 STRING PALINDROME ###################################


        //##################### START OF EXERCISE 90 STRING INTEGER? ################################
        public static bool IsInteger(string input)
        {
            // This function does not fulfill the second paragraph part of the question -- input is a given
            
            bool output = true;
            // remove all the leading and trailing spaces from the input
            input = input.Trim();
            // not integer if the string is empty
            if (String.IsNullOrEmpty(input))
            {
                output = false;
            }
            // case 1: only has one char which is not a number
            if (input.Length == 1 && !Char.IsDigit(input[0]))
            {
                output = false;
            }
            // case 2: string has more than one char: not integer if the first char is not '+', '-' or digit
            else if (input[0] != '+' && input[0] != '-' && char.IsDigit(input[0]))
            {
                output = false;
            }
            // case 3: string has more than one char
            // looping from second char to the end -- should all be digits
            else
            {
                for (int i = 1; i < input.Length; i++)
                {
                    if (!char.IsDigit(input[i]))
                    {
                        output = false;
                        break;
                    }
                }
            }

            return output;
        }

        //##################### END OF EXERCISE 90 STRING INTEGER? ###################################

        //##################### START OF EXERCISE 93 NEXT PRIME ################################
        public static int NextPrime(int input)
        {
            int output = input;
            while (IsPrime(output) != true)
            {
                output++;
            }

            return output;
        }

        public static bool IsPrime(int input)
        {
            bool output = true;
            
            if (input <=1)
            {
                output = false;
            }           

            for (int i = 2; i < input; i++)
            {
                if (input % i == 0)
                {
                    output = false;
                    break;
                }
            }

            return output;
        }

        //##################### END OF EXERCISE 93 NEXT PRIME ###################################
    }
}

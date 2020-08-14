using System;
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
        }

        //##################### START OF EXERCISE 11 FUEL EFFICIENCY ################################
        public void MPGToLPH(double mpg)
        {
            // 1 mile = 1.6km
            // 1 gallon = 3.79 liters
            // 1hpl = 1000km/1L = (1000/1.6)mile / (1/3.79)gallon
            // 1LPH = 1/1hpl

            double LPH = 1 / (mpg / ((1000 / 1.6) / (1 / 3.79)));
        }
        //##################### END OF EXERCISE 11 FUEL EFFICIENCY ###################################


        //##################### START OF EXERCISE 48 CHINESE ZODIAC ################################
        public void ChineseZodiac(int year)
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

        //##################### START OF EXERCISE 69 APPROXIMATE PAI ################################
        public void ApproxPai(int num)
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

        //##################### START OF EXERCISE 72 STRING PALINDROME ################################
        public void StringPalindrome(string input)
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

        //##################### START OF EXERCISE 93 NEXT PRIME ################################
        public int NextPrime(int input)
        {
            int output = input;
            while (IsPrime(output) != true)
            {
                output++;
            }

            return output;
        }

        public bool IsPrime(int input)
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

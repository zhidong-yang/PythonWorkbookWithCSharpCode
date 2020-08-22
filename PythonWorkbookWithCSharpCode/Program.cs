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


        //##################### START OF EXERCISE 89 CAPITALIZE IT ################################
        public static void Capitalize(string message)
        {
            // Assuming this is only English language so we don't need to consider other punctuation in languages such as Spanish
            // Also not including proper noun's capitalization
            // capitalize the first letter in the message
            // capitalize the first letter after certain punctuation
            StringBuilder result = new StringBuilder();
            
            char[] endingPunctuation = { '.', '!', '?' };
            bool flag = true;

            for (int i = 0; i < message.Length; i++)
            {
                // capitalize the letter "I"
                if (i > 0 && i < (message.Length - 1) && message[i] == 'i')
                {
                    if ((endingPunctuation.Contains(message[i - 1]) || message[i-1] == ' ')
                        && (message[i+1] == ' ') || (endingPunctuation.Contains(message[i + 1])))
                    {
                        flag = true;
                    }                    
                }
                else if (message[i] == 'i' && (i == message.Length-1)) // if 'i' appears as the last char of the message
                {
                    flag = true;
                }

                if (endingPunctuation.Contains(message[i]))
                {
                    flag = true;
                }

                if (Char.IsLetter(message[i]) && flag)
                {
                    // check the letter is lower case based on ASCII
                    if ((int)message[i] >= 97)
                    {
                        char capitalizedChar = (char)((int)message[i] - 32);
                        result.Append(capitalizedChar);
                    }
                    else
                    {
                        result.Append(message[i]);
                    }

                    flag = false;
                }
                else
                {
                    result.Append(message[i]);
                }
            }

            string output = result.ToString();

            Console.WriteLine($"After correct capitalization, the message becomes: {output}");
        }

        //##################### END OF EXERCISE 89 CAPITALIZE IT ###################################


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


        //##################### START OF EXERCISE 112 ABOVE AND BELOW AVERAGE ################################
        public static void AverageReport()
        {
            List<int> userInputs = new List<int>();
            Console.Write("Please enter an integer(press enter key to finish): "); // Assuming user input is a valid integer
            string numInString = Console.ReadLine();
            while (!String.IsNullOrEmpty(numInString))
            {
                int num = Convert.ToInt32(numInString);
                userInputs.Add(num);
                Console.Write("Please enter an integer(press enter key to finish): ");
                numInString = Console.ReadLine();
            }

            double average = (userInputs.Average()) * 1.0;
            List<int> belowAverage = new List<int>();
            List<int> equalToAverage = new List<int>();
            List<int> aboveAverage = new List<int>();

            for (int i = 0; i < userInputs.Count; i++)
            {
                if (userInputs[i] < average)
                {
                    belowAverage.Add(userInputs[i]);
                }
                else if (userInputs[i] > average)
                {
                    aboveAverage.Add(userInputs[i]);
                }
                else
                {
                    equalToAverage.Add(userInputs[i]);
                }
            }

            if (belowAverage.Count > 0)
            {
                Console.Write("The numbers below average are: ");
                foreach (int item in belowAverage)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

            if (equalToAverage.Count > 0)
            {
                Console.Write("The numbers equal to average are: ");
                foreach (int item in equalToAverage)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

            if (aboveAverage.Count > 0)
            {
                Console.Write("The numbers above average are: ");
                foreach (int item in aboveAverage)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        //##################### END OF EXERCISE 112 ABOVE AND BELOW AVERAGE ###################################


        //##################### START OF EXERCISE 131 MORSE CODE ################################
        public static string MorseCode(string input)
        {
            // Build the morse code library
            Dictionary<char, string> morseCode = new Dictionary<char, string>();
            morseCode['A'] = ".-";
            morseCode['B'] = "-...";
            morseCode['C'] = "-.-.";
            morseCode['D'] = "-..";
            morseCode['E'] = ".";
            morseCode['F'] = "..-.";
            morseCode['G'] = "--.";
            morseCode['H'] = "....";
            morseCode['I'] = "..";
            morseCode['J'] = ".---";
            morseCode['K'] = "-.-";
            morseCode['L'] = ".-..";
            morseCode['M'] = "--";
            morseCode['N'] = "-.";
            morseCode['O'] = "---";
            morseCode['P'] = ".--.";
            morseCode['Q'] = "--.-";
            morseCode['R'] = ".-.";
            morseCode['S'] = "...";
            morseCode['T'] = "-";
            morseCode['U'] = "..-";
            morseCode['V'] = "...-";
            morseCode['W'] = ".--";
            morseCode['X'] = "-..-";
            morseCode['Y'] = "-.--";
            morseCode['Z'] = "--..";
            morseCode['0'] = "-----";
            morseCode['1'] = ".----";
            morseCode['2'] = "..---";
            morseCode['3'] = "...--";
            morseCode['4'] = "....-";
            morseCode['5'] = ".....";
            morseCode['6'] = "-....";
            morseCode['7'] = "--...";
            morseCode['8'] = "---..";
            morseCode['9'] = "----.";

            // building the new string for output
            StringBuilder codedWord = new StringBuilder();
            input = input.ToUpper();
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetterOrDigit(input[i]))
                {
                    codedWord.Append(morseCode[input[i]]);
                    codedWord.Append(" ");
                }
            }

            string output = codedWord.ToString();

            return output;
        }

        //##################### END OF EXERCISE 131 MORSE CODE ##################################


        //##################### START OF EXERCISE 165 GREATEST COMMON DIVISOR ################################
        public static int GCD(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException();
            }
            if (b == 0)
            {
                return a;
            }
            else
            {
                int c = a % b;
                return GCD(b, c);
            }
        }
        //###################### END OF EXERCISE 165 GREATEST COMMON DIVISOR #################################

    }
}

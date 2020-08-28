using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonWorkbookProj2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadLine();
        }

        //##################### START OF EXERCISE 73 MULTIPLE WORDS PALINDROME ################################
        public static bool PalindromePhrase(string input)
        {
            bool output = true;

            input = input.ToLower();
            int start = 0;
            int end = input.Length - 1;

            while (start<end)
            {
                if (Char.IsLetter(input[start]) && Char.IsLetter(input[end]))
                {
                    if (input[start] != input[end])
                    {
                        output = false;
                        break;
                    }

                    start++;
                    end--;
                }
                else if (!Char.IsLetter(input[start]) && Char.IsLetter(input[end]))
                {
                    start++;
                }
                else if (Char.IsLetter(input[start]) && !Char.IsLetter(input[end]))
                {
                    end--;
                }
                else
                {
                    start++;
                    end--;
                }
            }

            return output;
        }
        //###################### END OF EXERCISE 73 MULTIPLE WORDS PALINDROME #################################


        //##################### START OF EXERCISE 79 MAX INTEGER ################################
        public static int Partition(int[] inputArray, int start, int end)
        {
            int pivotValue = inputArray[end];

            int i = start - 1;
            for (int j = 0; j < inputArray.Length-1; j++)
            {
                if (inputArray[j]<pivotValue)
                {
                    i++;

                    int temp1 = inputArray[i];
                    inputArray[i] = inputArray[j];
                    inputArray[j] = temp1;
                }
            }

            i++;
            int temp2 = inputArray[i];
            inputArray[i] = inputArray[end];
            inputArray[end] = temp2;

            return i;
        }
        public static void QuickSort(int[] inputArray, int start, int end)
        {
            if (start < end)
            {
                int pivotIndex = Partition(inputArray, start, end);
                QuickSort(inputArray, start, pivotIndex - 1);
                QuickSort(inputArray, pivotIndex+1, end);
            }
        }
        public static int MaxInteger(int[] inputArray)
        {
            QuickSort(inputArray, 0, inputArray.Length - 1);
            return inputArray[inputArray.Length - 1];
        }
        //###################### END OF EXERCISE 79 MAX INTEGER #################################


        //##################### START OF EXERCISE 94 RANDOM PASSWORD ################################
        public static string RandomPW()
        {
            Random rdn = new Random();
            // generate the number of characters in the output
            int charNum = rdn.Next(7, 11);
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < charNum; i++)
            {
                // randomly generating an ASCII number based on question's requirement, then casting it to char
                int ascii = rdn.Next(33, 127);
                char asciiCasted = (char)ascii;
                password.Append(asciiCasted);
            }

            string output = password.ToString();

            return output;
        }
        //###################### END OF EXERCISE 94 RANDOM PASSWORD #################################


        //##################### START OF EXERCISE 102 REDUCED MEASURES ################################
        public enum IngredientVolumn 
        { 
            Cup,
            Tablespoon,
            Teaspoon
        };
        public static string ReducedMeasures(int num, IngredientVolumn volumnUnit)
        {
            if (num <= 0)
            {
                throw new ArgumentException("The amount of ingredient volumn cannot be negative.");
            }
            
            string output;
            // Discuss each scenario based on input volumnUnit
            if (volumnUnit == IngredientVolumn.Cup)
            {
                output = $"{num} cup(s)";              
            }
            else if (volumnUnit == IngredientVolumn.Tablespoon)
            {
                // 1 cup = 16 tablespoons
                if (num >= 16)
                {
                    int cupNum = num / 16;
                    int tablespoon = (num % 16);
                    output = $"{cupNum} cup(s), {tablespoon} tablespoon(s)";
                }
                else
                {
                    output = $"{num} tablespoon(s)";
                }
            }
            else
            {
                // t cup = 16 tablespoons = 48 teaspoons
                if (num >= 48)
                {
                    int cupNum = num / 48;
                    int tablespoon = (num % 48) / 3;
                    if (tablespoon == 0)
                    {
                        int teaspoon = num % 48;
                        if (teaspoon != 0)
                        {
                            output = $"{cupNum} cup(s), {teaspoon} teaspoon(s)"; 
                        }
                        else
                        {
                            output = $"{cupNum} cup(s)";
                        }
                    }
                    else
                    {
                        int teaspoon = (num % 48) % 3;
                        if (teaspoon != 0)
                        {
                            output = $"{cupNum} cup(s), {tablespoon} tablespoon(s), {teaspoon} teaspoon(s)";
                        }
                        else
                        {
                            output = $"{cupNum} cup(s), {tablespoon} tablespoon(s)";
                        }
                    }
                }
                else if(num >= 3)
                {
                    int tablespoon = num / 3;
                    int teaspoon = num % 3;
                    if (teaspoon != 0)
                    {
                        output = $"{tablespoon} tablespoon(s), {teaspoon} teaspoon(s)";
                    }
                    else
                    {
                        output = $"{tablespoon} tablespoon(s)";
                    }
                }
                else
                {
                    output = $"{num} teaspoon(s)";
                }
            }

            return output;
        }

        //###################### END OF EXERCISE 102 REDUCED MEASURES #################################


        //##################### START OF EXERCISE 115 PIG LATIN ################################
        public static string PigLatin(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            // designating the list of vowels
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            
            StringBuilder firstPart = new StringBuilder();
            StringBuilder secondPart = new StringBuilder();
            string output = "";

            // if the starting letter of input is a vowel
            if (vowels.Contains(input[0]))
            {
                foreach (var item in input)
                {
                    firstPart.Append(item);
                }

                firstPart.Append("way");
                output = firstPart.ToString();
            }

            // if the starting letter of input is a consonant
            else
            {
                int firstVowelIndex = 0;
                while (firstVowelIndex < input.Length)
                {
                    if (!vowels.Contains(input[firstVowelIndex]))
                    {
                        secondPart.Append(input[firstVowelIndex]);
                        firstVowelIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                secondPart.Append("ay");

                for (int i = firstVowelIndex; i < input.Length; i++)
                {
                    firstPart.Append(input[i]);
                }

                firstPart.Append(secondPart);

                output = firstPart.ToString();
            }

            return output;
        }
        //###################### END OF EXERCISE 115 PIG LATIN #################################



        //##################### START OF EXERCISE 135 ANAGRAMS ################################
        public static bool IsAnagram(string input1, string input2)
        {
            bool output = false;
            // Create a dictionary to see if they have the same letters and number of each letter
            Dictionary<char, int> firstWordRef = new Dictionary<char, int>();
            Dictionary<char, int> secondWordRef = new Dictionary<char, int>();
            for (int i = 0; i < input1.Length; i++)
            {
                if (firstWordRef.ContainsKey(input1[i]))
                {
                    firstWordRef[input1[i]]++;
                }
                else
                {
                    firstWordRef[input1[i]] = 1;
                }
            }
            for (int i = 0; i < input2.Length; i++)
            {
                if (secondWordRef.ContainsKey(input2[i]))
                {
                    secondWordRef[input2[i]]++;
                }
                else
                {
                    secondWordRef[input2[i]] = 1;
                }
            }
            // if two dictionaries do not have the same number of key-value pairs, not anagram
            if (firstWordRef.Count != secondWordRef.Count)
            {
                return output;
            }
            // if two dictionaries have the same number of key-value pairs, but key-value pairs do not match, not anagrams
            foreach (var item in firstWordRef)
            {
                if (!secondWordRef.ContainsKey(item.Key) || secondWordRef[item.Key] != item.Value)
                {
                    return output;
                }
            }
            // make sure they are not the same words
            if (String.Compare(input2,input1) == 0)
            {
                return output;
            }

            // we can say they are anagrams after filtering above scenarios
            output = true;
            return output;
        }
        //###################### END OF EXERCISE 135 ANAGRAMS #################################
    }
}

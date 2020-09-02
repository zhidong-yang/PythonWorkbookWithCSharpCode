using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonWorkbookWithCSharpCode
{
    public static class QuestionsPageThree
    {
        //##################### START OF EXERCISE 85 CONVERT INT TO ORD ##################################
        public static string IntToOrd(int input)
        {
            Dictionary<int, string> referenceList = new Dictionary<int, string>();
            referenceList[1] = "first";
            referenceList[2] = "second";
            referenceList[3] = "third";
            referenceList[4] = "forth";
            referenceList[5] = "fifth";
            referenceList[6] = "sixth";
            referenceList[7] = "seventh";
            referenceList[8] = "eighth";
            referenceList[9] = "ninth";
            referenceList[10] = "tenth";
            referenceList[11] = "eleventh";
            referenceList[12] = "twelfth";

            string output;
            if (input > 0 && input < 13)
            {
                output = referenceList[input];
            }
            else
            {
                throw new ArgumentException("please enter a number between 1 and 12");
            }

            return output;
        }

        //###################### END OF EXERCISE 85 CONVERT INT TO ORD ###################################
        

        //##################### START OF EXERCISE 86 12 DAYS OF XMAS ##################################
        public static void TwelveDaysXMas(int input)
        {
            string ordDay = IntToOrd(input);

            Dictionary<int, string> lineForTheDay = new Dictionary<int, string>();
            lineForTheDay[1] = "And a patridge in a pear tree.";
            lineForTheDay[2] = "Two turtle doves,";
            lineForTheDay[3] = "Three French hens,";
            lineForTheDay[4] = "Four calling birds,";
            lineForTheDay[5] = "Five gold rings, badam-pam-pam,";
            lineForTheDay[6] = "Six geese a laying,";
            lineForTheDay[7] = "Seven swans a swimming,";
            lineForTheDay[8] = "Eight maids a milking";
            lineForTheDay[9] = "Nine ladies dancing";
            lineForTheDay[10] = "Ten lords a leaping,";
            lineForTheDay[11] = "Eleven pipers piping,";
            lineForTheDay[12] = "Twelve drummers drumming,";

            Stack<string> stackedLines = new Stack<string>();
            for (int i = 1; i < input+1; i++)
            {
                stackedLines.Push(lineForTheDay[i]);
            }

            Console.WriteLine($"On the {ordDay} day of Christmas");
            Console.WriteLine("My true love sent to me:");
            if (input == 1)
            {
                Console.WriteLine("A patridge in a pear tree.");
            }
            else if (input > 1 && input < 13)
            {
                for (int i = 0; i < input; i++)
                {
                    Console.WriteLine(stackedLines.Pop()); 
                }
            }
            else
            {
                throw new ArgumentException("The song only contains Day 1 through Day 12!");
            }
        }

        //###################### END OF EXERCISE 86 12 DAYS OF XMAS ###################################


        //##################### START OF EXERCISE 100 DAYS IN MONTH ##################################
        public static int DaysInMonth(int month, int year)
        {
            // month is two digit int, and year, four-digit
            int[] thirtyOneDayMonths = { 1, 3, 5, 7, 8, 10, 12 };
            int[] thirtyDayMonths = { 4, 6, 9, 11 };
            int output;
            if (thirtyOneDayMonths.Contains(month))
            {
                output = 31;
            }
            else if (thirtyDayMonths.Contains(month))
            {
                output = 30;
            }
            else if (month == 2)
            {
                if (year%400 == 0)
                {
                    output = 29;
                }
                else if (year%100 == 0)
                {
                    output = 28;
                }
                else if (year%4 == 0)
                {
                    output = 29;
                }
                else
                {
                    output = 28;
                }
            }
            else
            {
                throw new ArgumentException("Please enter a month number between 1 and 12");
            }

            return output;
        }

        //###################### END OF EXERCISE 100 DAYS IN MONTH ###################################


        //##################### START OF EXERCISE 113 Magic Date ##################################
        public static bool MagicDate(string input)
        {
            bool output = false;
            // try parse the input into a specific format of datetime
            if (DateTime.TryParse(input, out DateTime dateResult))
            {
                // convert the datetime into a string
                string dateString = dateResult.ToString("yy-MM-dd");

                // extract the specific positions of the string and convert them to int, and check if they are magic dates.
                int year = Convert.ToInt32(dateString.Substring(0, 2));
                int month = Convert.ToInt32(dateString.Substring(3, 2));
                int day = Convert.ToInt32(dateString.Substring(6, 2));

                if (year == month*day)
                {
                    output = true;
                }

                return output;
            }
            else
            {
                throw new ArgumentException("The date entry is not valid.");
            }
            
        }        
        public static List<string> MagicDatesInACentury()
        {
            List<string> output = new List<string>();
            for (int i = 1901; i < 2001; i++) // all the years in 20th century
            {
                for (int j = 1; j < 13; j++) //months in a year
                {
                    // calling functions from Q#100
                    for (int k = 1; k < DaysInMonth(j,i)+1; k++) // days in a month based on year and month
                    {
                        string newDate = new DateTime(i, j, k).ToString("yyyy-MM-dd");
                        if (MagicDate(newDate))
                        {
                            output.Add(newDate);
                        }
                    }
                }
            }

            return output;
        }
        //###################### END OF EXERCISE 113 Magic Date ###################################
    }


}

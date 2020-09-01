using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonWorkbookWithCSharpCode
{
    public static class QuestionsPageThree
    {
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

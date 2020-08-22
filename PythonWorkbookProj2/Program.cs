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
            Console.WriteLine(RandomPW());            

            Console.ReadLine();
        }

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
    }
}

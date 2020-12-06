using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("../../input.txt");
            List<Password> list1 = new List<Password>();
            int correctPass = 0;
            int correctSecondCritia = 0;

            while (streamReader.Peek() > 0)
            {
                Password pass = new Password();
                string input = streamReader.ReadLine();
                string[] range = Regex.Split(input, @"\D+");
                pass.Range[0] = System.Convert.ToInt32(range[0]);
                pass.Range[1] = System.Convert.ToInt32(range[1]);


                string[] letter = Regex.Split(input, @"\s");
                pass.Letter = letter[1].Substring(0, 1).ToCharArray()[0];
                pass.Pass = letter[2];
                list1.Add(pass);
            }
            
            foreach(Password pass in list1)
            {
                int numTimes = pass.Pass.Count(X => X == pass.Letter);
                if (numTimes >= pass.Range[0] && numTimes <= pass.Range[1])
                {
                    correctPass++;
                }

                if (pass.Pass.ElementAt(pass.Range[0] - 1) == pass.Letter 
                    && pass.Pass.ElementAt(pass.Range[1] - 1) != pass.Letter)
                {
                    correctSecondCritia++;
                } else if (pass.Pass.ElementAt(pass.Range[0] - 1) != pass.Letter
                    && pass.Pass.ElementAt(pass.Range[1] - 1) == pass.Letter)
                {
                    correctSecondCritia++;
                }
            }

            Console.WriteLine(correctPass);
            Console.WriteLine(correctSecondCritia);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("../../input.txt");
            List<int> list1 = new List<int>();
            int currentPosition = 0;
            bool resultFound = false;
            int multiplyValue = 0;

            while (streamReader.Peek() > 0)
            {
                list1.Add(System.Convert.ToInt32(streamReader.ReadLine().ToString()));
            }

            while (currentPosition < list1.Count)
            {
                for (int i = currentPosition + 1; i < list1.ToArray().Count(); i++)
                {
                    if (list1.ElementAt(i) + list1.ElementAt(currentPosition) == 2020)
                    {
                        resultFound = true;
                        multiplyValue = list1.ElementAt(i++) * list1.ElementAt(currentPosition);
                        break;
                    }
                }
                if (resultFound)
                    break;
                currentPosition++;
            }
            Console.WriteLine(multiplyValue);
            Console.ReadKey();
        }
    }
}

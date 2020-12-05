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
            bool firstResultFound = false;
            bool secondResultFound = false;
            int multiplyTwoValue = 0;
            int multiplyThreeValue = 0;

            while (streamReader.Peek() > 0)
            {
                list1.Add(System.Convert.ToInt32(streamReader.ReadLine().ToString()));
            }

            while (currentPosition < list1.Count)
            {
                for (int i = currentPosition + 1; i < list1.ToArray().Count(); i++)
                {
                    if (!firstResultFound)
                    {
                        if (list1.ElementAt(i) + list1.ElementAt(currentPosition) == 2020)
                        {
                            firstResultFound = true;
                            multiplyTwoValue = list1.ElementAt(i) * list1.ElementAt(currentPosition);
                        }
                    }

                    if (!secondResultFound)
                    {
                        for (int k = i + 1; k < list1.Count - 2; k++)
                        {
                            if (list1.ElementAt(i) + list1.ElementAt(k) + list1.ElementAt(currentPosition) == 2020)
                            {
                                secondResultFound = true;
                                multiplyThreeValue = list1.ElementAt(i) * list1.ElementAt(k) * list1.ElementAt(currentPosition);
                            }
                        }
                    }

                    if (firstResultFound & secondResultFound)
                        break;
                }
                if (firstResultFound & secondResultFound)
                    break;
                currentPosition++;
            }
            Console.WriteLine(multiplyTwoValue);
            Console.WriteLine(multiplyThreeValue);
            Console.ReadKey();
        }
    }
}

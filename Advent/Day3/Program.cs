using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("../../input.txt");
            List<string> list1 = new List<string>();
            int numTree = 0;
            int lineNo = 1;
            int charAt = 3;

            while (streamReader.Peek() > 0)
            {
                list1.Add(streamReader.ReadLine().ToString());
            }

            char[,] input = new char[list1.Count, list1[1].Length];

            for (int i = 0; i < list1.Count; i++)
            {
                for (int k = 0; k < list1[1].ToCharArray().Length; k++)
                {
                    input[i, k] = list1[i].ToCharArray()[k];
                }
            }

            // Part 1
            while (lineNo < input.GetLength(0))
            {
                if (input[lineNo,  charAt % input.GetLength(1)] == '#')
                {
                    numTree++;
                }
                charAt += 3;
                lineNo += 1;
            }


            // Part 2
            /*
            Right 1, down 1.
            Right 3, down 1. 
            Right 5, down 1.
            Right 7, down 1.
            Right 1, down 2.
            */

            int[,] paths = new int[,] { {1, 1}, { 3 , 1 }, { 5, 1 }, {7, 1}, { 1, 2} };
            List<int> result = new List<int>();
            
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                lineNo = paths[i, 1];
                charAt = paths[i, 0];
                numTree = 0;
                while (lineNo < input.GetLength(0))
                {
                    if (input[lineNo, charAt % input.GetLength(1)] == '#')
                    {
                        numTree++;
                    }
                    charAt += paths[i, 0];
                    lineNo += paths[i, 1];
                }
                result.Add(numTree);
            }
            int multiplication = 1;
            foreach(int i in result)
            {
                multiplication *= i;
            }

            Console.WriteLine(multiplication);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("../../input.txt");
            List<string> list1 = new List<string>();
            List<Passport> passList = new List<Passport>();
            string item = string.Empty;
            int isValid = 0;

            while (streamReader.Peek() > 0)
            {
                string tmp = streamReader.ReadLine().ToString();

                if (tmp.Trim() == "")
                {
                    list1.Add(item);
                    item = "";
                } else
                {
                    item += " " + tmp;
                }
            }

            list1.Add(item.Trim());

            foreach (string str in list1)
            {
                string[] items = str.Split(' ');
                Passport pass = new Passport();

                foreach (string info in items)
                {
                    string[] keyValu = info.Split(':');

                    switch (keyValu[0])
                    {
                        case "byr":
                            pass.Byr = keyValu[1];
                            break;
                        case "iyr":
                            pass.Iyr = keyValu[1];
                            break;
                        case "eyr":
                            pass.Eyr = keyValu[1];
                            break;
                        case "hgt":
                            pass.Hgt = keyValu[1];
                            break;
                        case "hcl":
                            pass.Hcl = keyValu[1];
                            break;
                        case "ecl":
                            pass.Ecl = keyValu[1];
                            break;
                        case "pid":
                            pass.Pid = keyValu[1];
                            break;
                        case "cid":
                            pass.Cid = keyValu[1];
                            break;
                        default:
                            break;
                    }
                }
                passList.Add(pass);
            }

            isValid = passList.Count;
            
            foreach (Passport pass in passList)
            {
                foreach (PropertyInfo propertyInfo in pass.GetType().GetProperties())
                {
                    if (string.IsNullOrEmpty((string)propertyInfo.GetValue(pass)))
                    {
                        if (propertyInfo.Name != "Cid")
                        {
                            isValid--;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(isValid);
            Console.ReadKey();
        }
    }
}

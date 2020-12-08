using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
                }
                else
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
                            if (System.Convert.ToInt32(keyValu[1]) >= 1920 && System.Convert.ToInt32(keyValu[1]) <= 2002)
                            {
                                pass.Byr = keyValu[1];
                            }
                            break;
                        case "iyr":
                            if (System.Convert.ToInt32(keyValu[1]) >= 2010 && System.Convert.ToInt32(keyValu[1]) <= 2020)
                            {
                                pass.Iyr = keyValu[1];
                            }
                            break;
                        case "eyr":
                            if (System.Convert.ToInt32(keyValu[1]) >= 2020 && System.Convert.ToInt32(keyValu[1]) <= 2030)
                            {
                                pass.Eyr = keyValu[1];
                            }
                            break;
                        case "hgt":
                            if (keyValu[1].ToLower().EndsWith("cm"))
                            {
                                if (System.Convert.ToInt32(keyValu[1].Substring(0, keyValu[1].Length - 2)) >= 150 && System.Convert.ToInt32(keyValu[1].Substring(0, keyValu[1].Length - 2)) <= 193)
                                {
                                    pass.Hgt = keyValu[1];
                                }
                            }
                            else if (keyValu[1].ToLower().EndsWith("in"))
                            {
                                if (System.Convert.ToInt32(keyValu[1].Substring(0, keyValu[1].Length - 2)) >= 59 && System.Convert.ToInt32(keyValu[1].Substring(0, keyValu[1].Length - 2)) <= 76)
                                {
                                    pass.Hgt = keyValu[1];
                                }
                            }
                            break;
                        case "hcl":
                            if (keyValu[1].StartsWith("#") && keyValu[1].Trim().Length == 7)
                            {
                                Match match = Regex.Match(keyValu[1].Substring(1), "[0-9a-z]");
                                if (match.Success)
                                {
                                    pass.Hcl = keyValu[1];
                                }
                            }
                            break;
                        case "ecl":
                            if (keyValu[1] == "amb" || keyValu[1] == "blu" ||
                                keyValu[1] == "brn" || keyValu[1] == "gry" ||
                                keyValu[1] == "grn" || keyValu[1] == "hzl" ||
                                keyValu[1] == "oth")

                            {
                                pass.Ecl = keyValu[1];
                            }
                            break;
                        case "pid":
                            if (keyValu[1].Trim().Length == 9)
                            {
                                Match match = Regex.Match(keyValu[1].Substring(1), "[0-9]");
                                if (match.Success)
                                {
                                    pass.Pid = keyValu[1];
                                }
                            }
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

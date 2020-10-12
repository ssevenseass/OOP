using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace OOP_1Lab
{
    class INIparser
{
    private static readonly Dictionary<string, Dictionary<string, string>> KeyOfPairs = new Dictionary<string, Dictionary<string, string>>();
    public INIparser(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(filename + "-file is not found");
            Console.ResetColor();
            Console.ReadKey(true);
            }
    
    string Section = "";

        foreach (string StrLine in File.ReadAllLines(filename))
        {
            string Str = StrLine.Split(';')[0];

            if (Str.StartsWith("[") && Str.EndsWith("]"))
            {
                Section = Str.Substring(1, Str.Length - 2);

                if (Regex.IsMatch(Section, @"[^a-zA-Z0-9_]"))
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Section + "- not a Section");
                    Console.ResetColor();
                    Console.ReadKey(true);
                    }

                KeyOfPairs.Add(Section, new Dictionary<string, string>());
            }

            else if (Str.Length > 0 && Str.Split('=').Length > 1)
            {
                if (Section == "")  
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Section + "- not Section");
                    Console.ResetColor();
                    Console.ReadKey(true);
                    }

                string Str1 = Str.Split('=')[0], Str2 = Str.Substring(Str1.Length + 2, Str.Length - Str1.Length - 2);
                Str1 = Str1.Substring(0, Str1.Length - 1);

                if (Regex.IsMatch(Str1, @"[^a-zA-Z0-9_]"))
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Str1 + " is not a name.");
                    Console.ResetColor();
                    Console.ReadKey(true);
                }

                KeyOfPairs[Section].Add(Str1, Str2);
               

            }

            else if (Str.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Str + "- not valid");
                Console.ResetColor();
                Console.ReadKey(true);

            }
        }


    }

    public string GetTheStringValue(string Section, string Name)
    {
        if (!KeyOfPairs.ContainsKey(Section))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("not Section");
            Console.ResetColor();
            Console.ReadKey(true);
            }

        if (!KeyOfPairs[Section].ContainsKey(Name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("not Name in Section");
            Console.ResetColor();
            Console.ReadKey(true);
            }

        return KeyOfPairs[Section][Name];
    }

    public int GetTheIntValue(string Section, string Name)
    {
        string str = GetTheStringValue(Section, Name);
            if (!Int32.TryParse(str, out int number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Section + " " + Name + "not integer");
                Console.ResetColor();
                Console.ReadKey(true);
            }

            return number;
    }

    public double GetTheDoubleValue(string Section, string Name)
    {
        string str = GetTheStringValue(Section, Name);
            if (!Double.TryParse(str, out double number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Section + " " + Name + "not double");
                Console.ResetColor();
                Console.ReadKey(true);
            }

            return number;
    }

    public string[] GetSection()
    {
        string[] number = new string[KeyOfPairs.Keys.Count];
        int i = 0;
        foreach (string key in KeyOfPairs.Keys)
        {
            number[i++] = key;
        }

        return number;
    }

    public string[] GetName(string Section)
    {
        if (!KeyOfPairs.ContainsKey(Section))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Section + "-not a Section");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        string[] number = new string[KeyOfPairs[Section].Keys.Count];
        int i = 0;
        foreach (string key in KeyOfPairs[Section].Keys)
        {
            number[i++] = key;
        }

        return number;
    }
  }
}
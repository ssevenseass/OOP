using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace OOP_1Lab
{
    class INIparser
    {
        private static readonly Dictionary<string, Dictionary<string, string>> KeyOfPairs =
            new Dictionary<string, Dictionary<string, string>>();

        public INIparser(string filename)
        {
            
            if (!File.Exists(filename))

                throw new FileIsNotFoundException("file is not found " + filename);


            string section = "";

            foreach (string strLine in File.ReadAllLines(filename))
            {
                string str = strLine.Split(';')[0];
                str = str.Replace(" ", "");

                if (str.StartsWith("[") && str.EndsWith("]"))
                {
                    section = str.Substring(1, str.Length - 2);

                    if (Regex.IsMatch(section, @"[^a-zA-Z0-9_]"))

                        throw new NotASection(section + "not Section");

                    KeyOfPairs.Add(section, new Dictionary<string, string>());
                    if (section != section?.Replace(" ", ""))
                    throw new NotASection("not a section");
                }

                else if (str.Length > 0 && str.Split('=').Length > 1)
                {
                    if (section == "")

                        throw new NotASection(section + "not Section");

                    string str1 = str.Split('=')[0], str2 = str.Substring(str1.Length, str.Length - str1.Length);
                    str1 = str1.Trim();
                    str2 = str2.Trim();
                    if (str1 != str1?.Replace(" ", ""))
                        throw new NotAName("not a name");
                        KeyOfPairs[section].Add(str1, str2);

                }

                else if (str.Length > 1)
                {

                    throw new WrongCommand("not valid" + str);

                }
            }
        }

        public string GetTheStringValue(string section, string name)
        {
            if (!KeyOfPairs.ContainsKey(section))
                throw new NotASection("not section");
            if (!KeyOfPairs[section].ContainsKey(name))
                throw new NotAName("not name in section");
            return KeyOfPairs[section][name];
        }


        public int GetTheIntValue(string section, string name)
        {
            string str = GetTheStringValue(section, name);
            if (!Int32.TryParse(str, out int number))
                throw new NotAnIntegerNumber(section + " " + name + "not integer");
            return number;
        }

        public double GetTheDoubleValue(string Section, string Name)
        {
            string str = GetTheStringValue(Section, Name);
            if (!Double.TryParse(str, out double number))
                throw new NotADoubleNumber(Section + " " + Name + "not double");
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

        public string[] GetName(string section)
        {
            if (!KeyOfPairs.ContainsKey(section))
                throw new NotASection("not Section");

            string[] number = new string[KeyOfPairs[section].Keys.Count];
            int i = 0;
            foreach (string key in KeyOfPairs[section].Keys)
            { 
                number[i++] = key;
            }

            return number;
        }
    }
}
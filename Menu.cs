using System;


namespace OOP_1Lab
{
    class Menu
    {
        static void Main(string[] args)

        {
            OOP_1Lab.INIparser iniparser = new OOP_1Lab.INIparser("test.ini");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MENU");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("All sections: ");
            foreach (string Section in iniparser.GetSection())
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(Section);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("1. how many sections do you want to see?");
            Console.ResetColor();
            string sectionss = Console.ReadLine();
            int s = Convert.ToInt32(sectionss);

            Console.WriteLine();

            for (int i = 0; i < s; ++i)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("2. Section whose names should be viewed");
                Console.ResetColor();
                string name_sec = Console.ReadLine();

                foreach (string names in iniparser.GetName(name_sec))
                {
                    Console.WriteLine(names);
                }

                Console.WriteLine();

            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("3. how many pieces do we need?");
            Console.ResetColor();

            string pieces = Console.ReadLine();
            int p = Convert.ToInt32(pieces);
            for (int i = 0; i < p; ++i)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("4. enter the name of Section");
                Console.ResetColor();
                string sect = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("5. enter the Name");
                Console.ResetColor();
                string namess = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("6. value: ");
                Console.WriteLine(iniparser.GetTheStringValue($"{sect}", $"{namess}"));
                Console.ResetColor();
            }
            Console.ReadKey(true);
        }
    }

}
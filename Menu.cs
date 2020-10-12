using System;


namespace OOP_1Lab
{
    class Menu
    {
        static void Main(string[] args)

        {
            try
            {

                OOP_1Lab.INIparser iniparser = new OOP_1Lab.INIparser("test.ini");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("MENU");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("All sections: ");
                foreach (string section in iniparser.GetSection())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(section);
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("1. how many sections do you want to see?");
                Console.ResetColor();
                var sectionss = Console.ReadLine();
                var s = Convert.ToInt32(sectionss);

                Console.WriteLine();

                for (int i = 0; i < s; ++i)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("2. Section whose names should be viewed");
                    Console.ResetColor();
                    string nameSec = Console.ReadLine();

                    foreach (string names in iniparser.GetName(nameSec))
                    {
                        Console.WriteLine(names);
                    }

                    Console.WriteLine();

                }

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("3. how many pieces do we need?");
                Console.ResetColor();

                var pieces = Console.ReadLine();
                var p = Convert.ToInt32(pieces);
                for (var i = 0; i < p; ++i)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("4. enter the name of Section");
                    Console.ResetColor();
                    var sect = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("5. enter the Name");
                    Console.ResetColor();
                    var namess = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("6. value: ");
                    Console.WriteLine(iniparser.GetTheStringValue($"{sect}", $"{namess}"));
                    Console.ResetColor();
                }

                Console.ResetColor();
                Console.ReadKey(true);
            }
            catch(NotASection ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileIsNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            catch (NotAName ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (WrongCommand ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotAnIntegerNumber ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotADoubleNumber ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
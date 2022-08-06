#region

using System;
using System.IO;

#endregion

namespace pumpY
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "pumpY";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            int HowMuch = 0;
            FileInfo TargetFile = null;

            if (args.Length != 2) ShowUsage();

            string ToPump = args[0];

            try
            {
                HowMuch = int.Parse(args[1]);
            }
            catch
            {
                print("> Usage: pumpy.exe \"FileToPump.exe\" \"10\"");
                Console.ReadKey();
                Environment.Exit(0);
            }

            try
            {
                TargetFile = new FileInfo(ToPump);
            }
            catch (Exception e)
            {
                print($"> Failed to get file informations. - {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }

            var FileMB = CalculateLength(TargetFile);
            var Filename = TargetFile.Name;

            print($"> File analyzed | {Filename} - {FileMB}MB");
            print($"> Pumping '{HowMuch}' MB...");

            try
            {
                var pumped = Pumper.Pump(TargetFile.FullName, HowMuch);
                var NewLength = CalculateLength(pumped);
                print($"> Success | {FileMB}mb => {NewLength}mb");
            }
            catch (Exception e)
            {
                print($"> Failed to process pump. - {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private static void ShowUsage()
        {
            const string asciilogo = @"

 ██▓███   █    ██  ███▄ ▄███▓ ██▓███ ▓██   ██▓
▓██░  ██▒ ██  ▓██▒▓██▒▀█▀ ██▒▓██░  ██▒▒██  ██▒
▓██░ ██▓▒▓██  ▒██░▓██    ▓██░▓██░ ██▓▒ ▒██ ██░
▒██▄█▓▒ ▒▓▓█  ░██░▒██    ▒██ ▒██▄█▓▒ ▒ ░ ▐██▓░
▒██▒ ░  ░▒▒█████▓ ▒██▒   ░██▒▒██▒ ░  ░ ░ ██▒▓░
▒▓▒░ ░  ░░▒▓▒ ▒ ▒ ░ ▒░   ░  ░▒▓▒░ ░  ░  ██▒▒▒ 
░▒ ░     ░░▒░ ░ ░ ░  ░      ░░▒ ░     ▓██ ░▒░ 
░░        ░░░ ░ ░ ░      ░   ░░       ▒ ▒ ░░  
            ░            ░            ░ ░     
                                      ░ ░     
";
            Console.Clear();
            Console.WriteLine(asciilogo);
            print("> Usage: pumpy.exe <Target File Path> <MB to pump>");
            print("> Example: pumpy.exe \"C:\\Target.exe\" 20");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static long CalculateLength(FileInfo fi)
        {
            return fi.Length / 1000000;
        }

        private static void print(string txt)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\nroot");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("pumpY");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(":");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"~ {txt}");
        }
    }
}
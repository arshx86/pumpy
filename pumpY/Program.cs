using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pumpY
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "pumpY";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            int HowMuch = 0;
            FileInfo TargetFile = null;

            if (args.Length != 2)
            {
                ShowUsage();
            }

            string ToPump = args[0];

            try
            {
                HowMuch = int.Parse(args[1]);
            }
            catch
            {
                print($"> Usage: pumpy.exe \"FileToPump.exe\" \"10\"");
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
                FileStream fileStream = File.OpenWrite(TargetFile.FullName);
                long num = fileStream.Seek(0L, SeekOrigin.End);
                int num2 = HowMuch;
                decimal d = new decimal(Convert.ToInt64((num2 * 1048576)) + fileStream.Length);
                while (decimal.Compare(new decimal(num), d) < 0)
                {
                    num += 1L;
                    fileStream.WriteByte(0);
                }

                fileStream.Close();
                var NewLength = CalculateLength(new FileInfo(TargetFile.FullName));
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

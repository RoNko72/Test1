using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Bankomat b = new Bankomat();
            b.Create();
            int n;
            string check = "";
            do
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("[ 1 ] Check avaliable bills");
                Console.WriteLine("[ 2 ] Input the money");
                Console.WriteLine("[ 3 ] Output the money");
                Console.WriteLine("[ 0 ] Exit");
                Console.WriteLine("-------------------------------------");
                Console.Write("  Input your choice: ");
                check = Console.ReadLine();
                if (check == "0" || check == "1" || check == "2" || check == "3")
                {
                    n = Convert.ToInt32(check);
                    switch (n)
                    {
                        case 1:
                            b.GetValues();
                            Console.WriteLine("");
                            break;
                        case 2:
                            b.Input();
                            Console.WriteLine("");
                            break;
                        case 3:
                            b.Output();
                            Console.WriteLine("");
                            break;
                        case 0:
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Input the correct operation number (1, 2, 3 or 0)");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Input the correct operation number (1, 2, 3 or 0)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                }
            }
            while (check != "0");
            Console.WriteLine("");
        }
    }
}

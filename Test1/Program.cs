using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static int fiveH, twoH, oneH, fifty, twenty, ten;
        static IDictionary<int, int> bills = new Dictionary<int, int>();
        static List<int> billsList = new List<int>();
        static int countOfMoneyInBankomat;

        static void Input()
        {
            /*Console.WriteLine("");
            Console.Write(" Input the count of 500 bill: ");
            fiveH = Convert.ToInt16(Console.ReadLine());
            Console.Write(" Input the count of 200 bill: ");
            twoH = Convert.ToInt16(Console.ReadLine());
            Console.Write(" Input the count of 100 bill: ");
            oneH = Convert.ToInt16(Console.ReadLine());
            Console.Write(" Input the count of 50 bill: ");
            fifty = Convert.ToInt16(Console.ReadLine());
            Console.Write(" Input the count of 20 bill: ");
            twenty = Convert.ToInt16(Console.ReadLine());
            Console.Write(" Input the count of 10 bill: ");
            ten = Convert.ToInt16(Console.ReadLine());*/
            fiveH = 5;
            twoH = 7;
            oneH = 3;
            fifty = 10;
            twenty = 21;
            ten = 43;
            //Console.WriteLine("");

            bills.Add(500, fiveH);
            bills.Add(200, twoH);
            bills.Add(100, oneH);
            bills.Add(50, fifty);
            bills.Add(20, twenty);
            bills.Add(10, ten);

            billsList.Add(500);
            billsList.Add(200);
            billsList.Add(100);
            billsList.Add(50);
            billsList.Add(20);
            billsList.Add(10);

            foreach (var bill in bills)
            {
                countOfMoneyInBankomat += bill.Key * bill.Value;
            }
        }

        static void Print()
        {
            Console.WriteLine("Avaliable bills: ");

            foreach (var bill in bills)
            {
                Console.WriteLine("  {0}  -  {1}",
                                            bill.Key,
                                            bill.Value);
            }
        }

        static void Task()
        {
            int sum = 0;
            List<int> res = new List<int>();
            string sumTry = "";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Input the count of money you want to output: ");
            sumTry = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            bool success = Int32.TryParse(sumTry, out sum);
            if (success)
            {
                if (sum <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input the correct sum! ( Your sum is <= 0)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                if (sum > countOfMoneyInBankomat)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Balance is lower than your sum :( ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    int tmp = 0;
                    foreach (var bill in bills)
                    {
                        while (sum >= bill.Key)
                        {
                            if (tmp < bill.Value)
                            {
                                sum -= bill.Key;
                                tmp++;
                            }
                            else
                                break;
                        }
                        res.Add(tmp);
                        tmp = 0;
                    }

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Result: " + string.Join(", ", res));
                    Console.ForegroundColor = ConsoleColor.White;

                    int k = 0;
                    while (k < billsList.Count)
                    {
                        bills[billsList[k]] -= res.ElementAt(k);
                        k++;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uncorrect sum!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            Input();
            int n;
            do
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("[ 1 ] Check avaliable bills");
                Console.WriteLine("[ 2 ] Output the money");
                Console.WriteLine("[ 0 ] Exit");
                Console.WriteLine("-------------------------------------");
                Console.Write("  Input your choice: ");
                n = Int32.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Print();
                        break;
                    case 2:
                        Task();
                        break;
                    case 0:
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Input the correct operation number (1, 2, 0)");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            while (n != 0);

            /*Console.WriteLine("   Data input ");
            Console.WriteLine("");
            Input();
            Console.WriteLine("=======================================");
            Console.WriteLine("");
            Console.WriteLine("   Client view");
            Console.WriteLine("");
            Task();*/
            Console.WriteLine("");
        }
    }
}

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
        }

        static void Task()
        {
            int sum = 0;

            IDictionary<int, int> bills = new Dictionary<int, int>();
            bills.Add(500, fiveH);
            bills.Add(200, twoH);
            bills.Add(100, oneH);
            bills.Add(50, fifty);
            bills.Add(20, twenty);
            bills.Add(10, ten);

            List<int> res = new List<int>();

            Console.WriteLine("Avaliable bills: ");
            for (int i = 0; i < bills.Count; i++)
            {
                Console.WriteLine("  {0}  -  {1}",
                                            bills.Keys.ElementAt(i),
                                            bills[bills.Keys.ElementAt(i)]);
            }
            Console.Write("Input the count of money you want to output: ");
            sum = Convert.ToInt16(Console.ReadLine());

            int tmp = 0;
            foreach(var bill in bills)
            {
                while (sum >= bill.Key)
                {
                    sum -= bill.Key;
                    if (tmp < bill.Value)
                        tmp++;
                    else
                        break;
                }
                res.Add(tmp);
                tmp = 0;
            }

            Console.WriteLine();
            Console.WriteLine(" Result: " + string.Join(", ", res));
        }

        static void Main(string[] args)
        {
            /*Console.WriteLine("   Data input ");
            Console.WriteLine("");*/
            Input();
            /*Console.WriteLine("=======================================");
            Console.WriteLine("");
            Console.WriteLine("   Client view");*/
            Console.WriteLine("");
            Task();
            Console.WriteLine("");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Test1
{
    class Bankomat
    {
        private int fiveH, twoH, oneH, fifty, twenty, ten, countOfMoneyInBankomat;
        private IDictionary<int, int> bills = new Dictionary<int, int>();
        private List<int> billsList = new List<int>();

        public void Create()
        {
            fiveH = 5;
            twoH = 7;
            oneH = 3;
            fifty = 10;
            twenty = 21;
            ten = 43;

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

        public void GetValues()
        {
            Console.WriteLine("Avaliable bills: ");

            foreach (var bill in bills)
            {
                Console.WriteLine("  {0}  -  {1}",
                                            bill.Key,
                                            bill.Value);
            }
        }

        public void Input()
        {
            int fiveHAdd, twoHAdd, oneHAdd, fiftyAdd, twentyAdd, tenAdd;
            string fiveHAddS, twoHAddS, oneHAddS, fiftyAddS, twentyAddS, tenAddS;

            Console.Write(" Input the count of 500 bill you want to add: ");
            fiveHAddS = Console.ReadLine();
            bool success = Int32.TryParse(fiveHAddS, out fiveHAdd);
            if (success)
            {
                Console.Write(" Input the count of 200 bill you want to add: ");
                twoHAddS = Console.ReadLine();
                success = Int32.TryParse(twoHAddS, out twoHAdd);
                if (success)
                {
                    Console.Write(" Input the count of 100 bill you want to add: ");
                    oneHAddS = Console.ReadLine();
                    success = Int32.TryParse(oneHAddS, out oneHAdd);
                    if (success)
                    {
                        Console.Write(" Input the count of 50 bill you want to add: ");
                        fiftyAddS = Console.ReadLine();
                        success = Int32.TryParse(fiftyAddS, out fiftyAdd);
                        if (success)
                        {
                            Console.Write(" Input the count of 20 bill you want to add: ");
                            twentyAddS = Console.ReadLine();
                            success = Int32.TryParse(twentyAddS, out twentyAdd);
                            if (success)
                            {
                                Console.Write(" Input the count of 10 bill you want to add: ");
                                tenAddS = Console.ReadLine();
                                success = Int32.TryParse(tenAddS, out tenAdd);
                                if (success)
                                {
                                    if (fiveHAdd  >= 0 && fiveHAdd  <= 999999 &&
                                        twoHAdd   >= 0 && twoHAdd   <= 999999 &&
                                        oneHAdd   >= 0 && oneHAdd   <= 999999 &&
                                        fiftyAdd  >= 0 && fiftyAdd  <= 999999 &&
                                        twentyAdd >= 0 && twentyAdd <= 999999 &&
                                        tenAdd    >= 0 && tenAdd    <= 999999)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(" Inputing bills...");
                                        
                                        bills[500] += fiveHAdd;
                                        bills[200] += twoHAdd;
                                        bills[100] += oneHAdd;
                                        bills[50] += fiftyAdd;
                                        bills[20] += twentyAdd;
                                        bills[10] += tenAdd;
                                        Console.WriteLine("Bills were successfuly inputed! ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(" Input other number! (Too high or negative value) ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Input the correct number! ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Output()
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
                    Console.WriteLine(" Outputting money...");
                    Console.WriteLine(" Money were successfuly outputed! ");
                    Console.WriteLine("");
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
    }
}

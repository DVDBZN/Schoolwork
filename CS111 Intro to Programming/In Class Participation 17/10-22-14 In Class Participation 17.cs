using System;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            double salary = 550;
            Console.WriteLine("Salesperson's Salary: {0:C2}", salary);
            Console.Write("Salesperson's Sales: ");
            string salesString = Console.ReadLine();
            double sales = double.Parse(salesString);

            if (sales <= 5000)
            {
                double rateOfCommission = .04;
                double commission = sales * rateOfCommission;
                Console.WriteLine("Commission: {0:C2}", commission);
                double totalEarnings = salary + commission;
                Console.WriteLine("Total Earnings: {0:C2}", totalEarnings);
            }

            if (sales > 5000)
            {
                if (sales <= 10000)
                {
                    double rateOfCommission = .09;
                    double commission = sales * rateOfCommission;
                    Console.WriteLine("Commission: {0:C2}", commission);
                    double totalEarnings = salary + commission;
                    Console.WriteLine("Total Earnings: {0:C2}", totalEarnings);
                }
            }
            if (sales > 10000)
            {
                if (sales <= 20000)
                {
                    double rateOfCommission = .14;
                    double commission = sales * rateOfCommission;
                    Console.WriteLine("Commission: {0:C2}", commission);
                    double totalEarnings = salary + commission;
                    Console.WriteLine("Total Earnings: {0:C2}", totalEarnings);
                }
            }
            if (sales > 20000)
            {
                double rateOfCommission = .19;
                double commission = sales * rateOfCommission;
                Console.WriteLine("Commission: {0:C2}", commission);
                double totalEarnings = salary + commission;
                Console.WriteLine("Total Earnings: {0:C2}", totalEarnings);
            }
        }
    }
}
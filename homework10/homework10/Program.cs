namespace homework10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var worker = new FileWorkerChild("txt", 14);
            worker.Read();
            worker.Write();
            worker.Edit();
            worker.Delete();

            FinanceOperations bank = new Bank();

            if (bank.CheckUserHistory())
            {
                double total = bank.CalculateLoanPercent(12, 100);
                Console.WriteLine($"bank total pay: {total}");
            }
            else
            {
                Console.WriteLine("nto approved");
            }
            FinanceOperations micro =new MicroFinance();
            if (micro.CheckUserHistory()) {
                double total = micro.CalculateLoanPercent(12, 200);
                Console.WriteLine($"microfinance total pay: {total}");
            }

        }
    }
}

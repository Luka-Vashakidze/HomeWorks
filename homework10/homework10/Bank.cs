using System;

namespace homework10
{
    public class Bank : FinanceOperations
    {
        public bool CheckUserHistory()
        {
            Random random = new Random();
            return random.Next(0, 2) == 1;
        }

        public double CalculateLoanPercent(int month, double amountPerMonth)
        {
            double principal = month * amountPerMonth;

            double interest = principal * 0.05;

            return principal + interest;
        }
    }
}
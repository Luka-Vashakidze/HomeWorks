namespace homework10
{
    public class MicroFinance : FinanceOperations
    {
        public bool CheckUserHistory()
        {
            return true;
        }

        public double CalculateLoanPercent(int month, double amountPerMonth)
        {
            double principal = month * amountPerMonth;

            double commission = principal * 0.10;

            double serviceFees = month * 4.0;

            return principal + commission + serviceFees;
        }
    }
}   
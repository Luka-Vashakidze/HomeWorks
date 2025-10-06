namespace homework10
{
    public interface FinanceOperations
    {
        double CalculateLoanPercent(int month, double amountPerMonth);
        bool CheckUserHistory();
    }
}
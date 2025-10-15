using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CardDetails CardDetails { get; set; }
        public string PinCode { get; set; }
        public Balances Balances { get; set; }
        public List<Transaction> TransactionHistory { get; set; }
    }

    public class CardDetails
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVC { get; set; }

        public bool IsValid()
        {
            return IsCvcValid() && IsCardNumberValid() && IsExpirationDateValid();
        }

        public bool IsCardNumberValid()
        {
            return CardNumber.Length == 16 && CardNumber.All(char.IsDigit);
        }

        public bool IsCvcValid()
        {
            return CVC.Length == 3 && CVC.All(char.IsDigit);
        }

        public bool IsExpirationDateValid()
        {
            if (ExpirationDate.Length != 5 || ExpirationDate[2] != '/')
                return false;

            string[] parts = ExpirationDate.Split('/');
            if (!int.TryParse(parts[0], out int month) || !int.TryParse(parts[1], out int year))
                return false;

            if (month < 1 || month > 12)
                return false;

            year += 2000;
            DateTime expiry = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            return expiry >= DateTime.Now;
        }
    }

    public class Balances
    {
        public decimal GEL { get; set; }
        public decimal USD { get; set; }
        public decimal EUR { get; set; }
    }

    public class Transaction
    {
        public string TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal AmountGEL { get; set; }
        public decimal AmountUSD { get; set; }
        public decimal AmountEUR { get; set; }
    }
}

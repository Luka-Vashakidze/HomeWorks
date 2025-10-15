using System;

namespace App
{
    public static class SimpleRates
    {
        private const decimal USD_TO_GEL = 2.7m;
        private const decimal EUR_TO_GEL = 2.9m;

        public static decimal Convert(string from, string to, decimal amount)
        {
            decimal gel = 0m;

            if (from == "GEL") gel = amount;
            else if (from == "USD") gel = amount * USD_TO_GEL;
            else if (from == "EUR") gel = amount * EUR_TO_GEL;
            else return 0m;

            if (to == "GEL") return Math.Round(gel, 2);
            if (to == "USD") return Math.Round(gel / USD_TO_GEL, 2);
            if (to == "EUR") return Math.Round(gel / EUR_TO_GEL, 2);

            return 0m;
        }
    }
}
using System;

namespace App
{
    public class ATMApp
    {
        private DataStore store;

        public ATMApp(DataStore s)
        {
            store = s;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    
                    Console.WriteLine("Welcome to ATM");
                    Console.WriteLine("--------------");

                    var user = Authenticate();
                    if (user == null)
                    {
                        Console.WriteLine("Authentication failed. Logging out.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        continue;
                    }

                    if (user.TransactionHistory == null)
                        user.TransactionHistory = new System.Collections.Generic.List<Transaction>();

                    bool stay = true;
                    while (stay)
                    {
                        
                        Console.WriteLine("1) View balance");
                        Console.WriteLine("2) Withdraw money");
                        Console.WriteLine("3) Last 5 operations");
                        Console.WriteLine("4) Deposit money");
                        Console.WriteLine("5) Change PIN code");
                        Console.WriteLine("6) Currency conversion");
                        Console.WriteLine("7) Logout");

                        string choice = Console.ReadLine();
                        if (choice == null) choice = "";

                        if (choice == "1")
                        {
                            Console.WriteLine("GEL: " + user.Balances.GEL.ToString("F2"));
                            Console.WriteLine("USD: " + user.Balances.USD.ToString("F2"));
                            Console.WriteLine("EUR: " + user.Balances.EUR.ToString("F2"));
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Withdraw currency (GEL/USD/EUR): ");
                            string currency = Console.ReadLine();
                            if (currency == null) currency = "";

                            Console.Write("Amount: ");
                            string sAmount = Console.ReadLine();
                            if (sAmount == null) sAmount = "";
                            decimal amount;
                            if (!decimal.TryParse(sAmount, out amount) || amount <= 0)
                            {
                                Console.WriteLine("Invalid amount.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            bool ok = (currency == "GEL" && user.Balances.GEL >= amount) ||
                                      (currency == "USD" && user.Balances.USD >= amount) ||
                                      (currency == "EUR" && user.Balances.EUR >= amount);
                            if (!ok)
                            {
                                Console.WriteLine("Insufficient funds.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            if (currency == "GEL") user.Balances.GEL = Math.Round(user.Balances.GEL - amount, 2);
                            if (currency == "USD") user.Balances.USD = Math.Round(user.Balances.USD - amount, 2);
                            if (currency == "EUR") user.Balances.EUR = Math.Round(user.Balances.EUR - amount, 2);

                            Transaction t = new Transaction();
                            t.TransactionDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            t.TransactionType = "Withdraw";
                            t.AmountGEL = currency == "GEL" ? -amount : 0;
                            t.AmountUSD = currency == "USD" ? -amount : 0;
                            t.AmountEUR = currency == "EUR" ? -amount : 0;
                            user.TransactionHistory.Add(t);

                            store.SaveUser(user);
                            SimpleLogger.Log("Withdraw " + amount + " " + currency + " for " + user.CardDetails.CardNumber);
                            Console.WriteLine("Withdrawal completed.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("--- LAST 5 OPERATIONS ---");
                            int count = user.TransactionHistory.Count;
                            if (count == 0)
                            {
                                Console.WriteLine("No transactions.");
                            }
                            else
                            {
                                
                                int start = count - 1;
                                int shown = 0;
                                for (int i = start; i >= 0 && shown < 5; i--)
                                {
                                    var t = user.TransactionHistory[i];
                                    Console.WriteLine($"{t.TransactionDate} | {t.TransactionType} | GEL:{t.AmountGEL} USD:{t.AmountUSD} EUR:{t.AmountEUR}");
                                    shown++;
                                }
                            }
                            Console.WriteLine("Press any key to continue ");
                            Console.ReadKey(true);
                        }
                        else if (choice == "4")
                        {
                            Console.Write("Deposit currency (GEL/USD/EUR): ");
                            var currency = Console.ReadLine().Trim().ToUpperInvariant();
                            if (currency != "GEL" && currency != "USD" && currency != "EUR")
                            {
                                Console.WriteLine("Unsupported currency.");
                                Console.WriteLine("Press any key to continue ");
                                Console.ReadKey(true);
                                continue;
                            }

                            Console.Write($"Amount in {currency}: ");
                            var s = Console.ReadLine().Trim();
                            decimal amount;
                            if (!decimal.TryParse(s, out amount) || amount <= 0)
                            {
                                Console.WriteLine("Invalid amount.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            if (currency == "GEL") user.Balances.GEL = Math.Round(user.Balances.GEL + amount, 2);
                            if (currency == "USD") user.Balances.USD = Math.Round(user.Balances.USD + amount, 2);
                            if (currency == "EUR") user.Balances.EUR = Math.Round(user.Balances.EUR + amount, 2);

                            var t = new Transaction
                            {
                                TransactionDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                TransactionType = "Deposit",
                                AmountGEL = currency == "GEL" ? amount : 0,
                                AmountUSD = currency == "USD" ? amount : 0,
                                AmountEUR = currency == "EUR" ? amount : 0
                            };
                            user.TransactionHistory.Add(t);

                            store.SaveUser(user);
                            SimpleLogger.Log($"Deposit {amount} {currency} for {user.CardDetails.CardNumber}");
                            Console.WriteLine("Deposit completed.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                        else if (choice == "5")
                        {
                            Console.Write("Enter new PIN (4 digits): ");
                            var pin1 = Console.ReadLine().Trim();

                            bool isValid = pin1.Length == 4 && pin1.All(char.IsDigit);

                            if (!isValid)
                            {
                                Console.WriteLine("PIN must be 4 digits.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            Console.Write("Repeat new PIN: ");
                            var pin2 = Console.ReadLine().Trim();

                            if (pin1 != pin2)
                            {
                                Console.WriteLine("PINs do not match.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            user.PinCode = pin1;

                            var t = new Transaction
                            {
                                TransactionDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                TransactionType = "ChangePIN",
                                AmountGEL = 0,
                                AmountUSD = 0,
                                AmountEUR = 0
                            };
                            user.TransactionHistory.Add(t);

                            store.SaveUser(user);
                            SimpleLogger.Log($"PIN changed for {user.CardDetails.CardNumber}");
                            Console.WriteLine("PIN changed.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                        else if (choice == "6")
                        {
                            Console.Write("Convert FROM (GEL/USD/EUR): ");
                            var from = Console.ReadLine().Trim().ToUpperInvariant();
                            Console.Write("Convert TO (GEL/USD/EUR): ");
                            var to = Console.ReadLine().Trim().ToUpperInvariant();

                            if (from != "GEL" && from != "USD" && from != "EUR")
                            {
                                Console.WriteLine("Unsupported currency.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                                continue;
                            }
                            if (to != "GEL" && to != "USD" && to != "EUR")
                            {
                                Console.WriteLine("Unsupported currency.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey(true);
                                continue;
                            }
                            if (from == to)
                            {
                                Console.WriteLine("Currencies are the same.");
                                Console.WriteLine("Press any key to continue ");
                                Console.ReadKey(true);
                                continue;
                            }

                            Console.Write($"Amount in {from}: ");
                            var s = Console.ReadLine().Trim();
                            decimal amount;
                            if (!decimal.TryParse(s, out amount) || amount <= 0)
                            {
                                Console.WriteLine("Invalid amount.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            bool hasMoney = (from == "GEL" && user.Balances.GEL >= amount) ||
                                            (from == "USD" && user.Balances.USD >= amount) ||
                                            (from == "EUR" && user.Balances.EUR >= amount);

                            if (!hasMoney)
                            {
                                Console.WriteLine("Insufficient funds.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            var converted = SimpleRates.Convert(from, to, amount);
                            if (converted <= 0)
                            {
                                Console.WriteLine("Conversion failed.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            if (from == "GEL") user.Balances.GEL = Math.Round(user.Balances.GEL - amount, 2);
                            if (from == "USD") user.Balances.USD = Math.Round(user.Balances.USD - amount, 2);
                            if (from == "EUR") user.Balances.EUR = Math.Round(user.Balances.EUR - amount, 2);

                            if (to == "GEL") user.Balances.GEL = Math.Round(user.Balances.GEL + converted, 2);
                            if (to == "USD") user.Balances.USD = Math.Round(user.Balances.USD + converted, 2);
                            if (to == "EUR") user.Balances.EUR = Math.Round(user.Balances.EUR + converted, 2);

                            var t = new Transaction
                            {
                                TransactionDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                TransactionType = $"Convert {from}->{to}",
                                AmountGEL = 0,
                                AmountUSD = 0,
                                AmountEUR = 0
                            };
                            if (from == "GEL") t.AmountGEL -= amount;
                            if (from == "USD") t.AmountUSD -= amount;
                            if (from == "EUR") t.AmountEUR -= amount;
                            if (to == "GEL") t.AmountGEL += converted;
                            if (to == "USD") t.AmountUSD += converted;
                            if (to == "EUR") t.AmountEUR += converted;
                            user.TransactionHistory.Add(t);

                            store.SaveUser(user);
                            SimpleLogger.Log($"Convert {amount} {from} -> {converted} {to} for {user.CardDetails.CardNumber}");
                            Console.WriteLine($"Converted {amount:F2} {from} to {converted:F2} {to}.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                        else if (choice == "7")
                        {
                            stay = false;
                            SimpleLogger.Log($"User logged out: {user.CardDetails.CardNumber}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid option.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SimpleLogger.Log("Unexpected error in Run: " + ex.Message);
                    Console.WriteLine("An error happened. Returning .");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                }
            }
        }

        private User Authenticate()
        {
            try
            {
                Console.Write("Enter Card number (16 digits): ");
                string cardNumber = Console.ReadLine();
                if (cardNumber == null) cardNumber = "";
                cardNumber = cardNumber.Trim();

                Console.Write("Enter Expiration date (MM/YY): ");
                string expiration = Console.ReadLine();
                if (expiration == null) expiration = "";
                expiration = expiration.Trim();

                Console.Write("Enter CVC (3 digits): ");
                string cvc = Console.ReadLine();
                if (cvc == null) cvc = "";
                cvc = cvc.Trim();

                bool cardOk = cardNumber.Length == 16;
                if (cardOk)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (!char.IsDigit(cardNumber[i])) { cardOk = false; break; }
                    }
                }

                bool expOk = false;
                if (expiration.Length == 5 && expiration[2] == '/')
                {
                    int m, y;
                    bool mOk = int.TryParse(expiration.Substring(0, 2), out m);
                    bool yOk = int.TryParse(expiration.Substring(3, 2), out y);
                    if (mOk && yOk && m >= 1 && m <= 12)
                    {
                        int fullY = 2000 + y;
                        DateTime now = DateTime.Now;
                        DateTime lastDay = new DateTime(fullY, m, 1).AddMonths(1).AddDays(-1);
                        expOk = lastDay.Date >= now.Date;
                    }
                }

                if (!cardOk || !expOk)
                {
                    Console.WriteLine("Invalid card information.");
                    SimpleLogger.Log("Invalid card info.");
                    return null;
                }

                User user = store.FindUserByCard(cardNumber);
                if (user == null)
                {
                    Console.WriteLine("Card not found.");
                    SimpleLogger.Log("Card not found: " + cardNumber);
                    return null;
                }

                if (user.CardDetails == null || user.CardDetails.ExpirationDate != expiration || user.CardDetails.CVC != cvc)
                {
                    Console.WriteLine("Card details do not match.");
                    SimpleLogger.Log("Card details mismatch for " + cardNumber);
                    return null;
                }

                bool pinOk = false;
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Enter PIN (4 digits): ");
                    string pin = Console.ReadLine();
                    if (pin == null) pin = "";
                    pin = pin.Trim();
                    if (pin == user.PinCode) { pinOk = true; break; }
                    Console.WriteLine("Incorrect PIN. Attempts left: " + (2 - i));
                    SimpleLogger.Log("Incorrect PIN for " + cardNumber);
                }

                if (!pinOk)
                {
                    Console.WriteLine("Too many attempts.");
                    SimpleLogger.Log("PIN attempts exceeded for " + cardNumber);
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                SimpleLogger.Log("Auth error: " + ex.Message);
                return null;
            }
        }
    }
}
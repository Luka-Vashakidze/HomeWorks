namespace Homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1

            //Console.WriteLine("Choose radius: ");
            //int radius = int.Parse(Console.ReadLine());
            //double bigSquareArea = 4 * radius * radius;
            //double smallSquareArea = 2 * radius * radius;

            //double difference = bigSquareArea - smallSquareArea;
            //Console.WriteLine($"difference between big and small square is : {difference}");


            ////2
            //Console.Write("Enter symbols: ");
            //string input = Console.ReadLine();

            //char firstChar = input[0];
            //bool jackpot = true;

            //foreach (char c in input)
            //{
            //    if (c != firstChar)
            //    {
            //        jackpot = false;
            //        break;
            //    }
            //}

            //if (jackpot)
            //{
            //    Console.WriteLine("Yes");
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}



            //3
            //Console.WriteLine("Enter number for each - Win Draw Lose: ");
            //string result = Console.ReadLine();
            //Console.WriteLine(result);
            //int totalPoints = 0;    

            //string[] results = result.Split(' ');
            //Dictionary <string, int> scores = new Dictionary<string, int>()
            //{
            //    {"Win", int.Parse(results[0])},
            //    {"Draw", int.Parse(results[1])},
            //    {"Lose", int.Parse(results[2])}
            //};

            //foreach (var score in scores)
            //{
            //    if (score.Key == "Win")
            //    {
            //        totalPoints += score.Value * 3;
            //    }
            //    else if (score.Key == "Draw")
            //    {
            //        totalPoints += score.Value * 1;
            //    }
            //    else
            //    {
            //        totalPoints += score.Value * 0;
            //    }
            //}
            //Console.WriteLine($"Total points: {totalPoints}"); 

            //4
            //Console.WriteLine("Enter hour sequence : ");    
            //string input = Console.ReadLine();
            //int[] hours = input.Split(' ').Select(int.Parse).ToArray();
            //int totalPay = 0; 
            //// 4 4 4 4 4 0 4
            //for(int i=0;i < hours.Length; i++)
            //{
            //    if(i >=0 && i < 5)
            //        if(hours[i] <= 8)
            //        {
            //            totalPay += hours[i] * 10;
            //        }
            //        else
            //        {
            //            totalPay += (8 * 10) + ((hours[i] - 8) * 15);
            //        }

            //    else if (i >= 5 && i <= 6)
            //        {
            //            totalPay += hours[i] * 20;
            //        }
            //}
            //Console.WriteLine(totalPay);


            //5
            // 5 8 8 9 10 - 3 
            // 5 5 5 5  - 0 

            //Console.WriteLine("Enter progress: ");
            //int[] progress = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int counter = 0;
            //for (int i = 0; i < progress.Length - 1; i ++ )
            //{
            //    if (progress[i + 1] > progress[i] )
            //    {
            //        counter++;
            //    }

            //}
            //Console.WriteLine(counter);

            //6 

            Console.WriteLine("enter N for length: ");
            int n = int.Parse(Console.ReadLine());  
            Console.WriteLine("Enter words: ");   
            string[] words = Console.ReadLine().Split(' ');

            var results = words.Where(w => w.Length >= n);
            Console.WriteLine(string.Join(" ", results));   


        }
    }
}

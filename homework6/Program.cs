namespace homework6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            Console.WriteLine("Enter n for size: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            var evenNums = arr.Where(x => x % 2 == 0).ToArray();
            var oddNums = arr.Where(x => x % 2 != 0).ToArray();

            Console.WriteLine("even nums : " + string.Join(" ", evenNums));
            Console.WriteLine("odd nums : " + string.Join(" ", oddNums));
            #endregion

            #region
            Dictionary<string, string> contacts = new Dictionary<string, string>();

            while (true)
            {
                Console.Write("enter name or 'exit' to stop: ");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                    break;

                Console.Write("enter phone: ");
                string phone = Console.ReadLine();

                contacts[name] = phone; 
            }

            Console.WriteLine("\nContacts:");
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.Key} - {c.Value}");
            }
            #endregion

            #region
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            Console.WriteLine("Enter numbers for List: ");
            string inputList = Console.ReadLine();

            foreach (var num in inputList.Split(' ').Select(int.Parse))
            {
                if (numbers.ContainsKey(num))
                    numbers[num]++; 
                else
                    numbers[num] = 1;  
            }
            foreach(var pair in numbers)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }   
            #endregion

            List<int> numbersList = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("Enter count: ");
            int count = int.Parse(Console.ReadLine());

            var result = numbersList.OrderBy(x => x); // incomplete

        }
    }
}

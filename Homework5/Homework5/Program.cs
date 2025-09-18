namespace Homework5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("Enter your number for check: ");
            int number = int.Parse(Console.ReadLine());
            if (number % 5 == 0)
            {
                Console.WriteLine("Yes");

            }
            else
            {
                Console.WriteLine("NO");
            }
            //2
            Console.WriteLine("Enter your first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            int max = Math.Max(firstNumber, secondNumber);
            int min = Math.Min(firstNumber, secondNumber);

            int sum = firstNumber + secondNumber;
            Console.WriteLine($"Sum of numbers:{firstNumber} + {secondNumber} = {sum}");

            int difference = max - min;
            Console.WriteLine($"difference of numbers:{max} - {min} = {difference}");

            int product = firstNumber * secondNumber;
            Console.WriteLine($"Product of numbers:{firstNumber} * {secondNumber} = {product}");

            if (min == 0)
            {
                Console.WriteLine("not allowed to divide by zero");
            }
            else
            {
                double division = (double)max / min;
                Console.WriteLine($"Division of number: {max} / {min} = {division} ");
            }

            //3
            Console.WriteLine("enter your first number: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter your second number: ");
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Your numbers are: number1 = {number1} and number2 = {number2}");
            int temp;
            temp = number1;
            number1 = number2;
            number2 = temp;
            Console.WriteLine($"after switch number1 = {number1} and number2 = {number2}");

            //4
            Console.WriteLine("enter your number: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 9; i++)
            {
                int result = num * i;
                Console.WriteLine($"{num} * {i} = {result}");

            }   

            //5
            Console.WriteLine("enter your number: ");
            int num5 = int.Parse(Console.ReadLine());
            for(int i = 2; i <= num5; i += 2)
            {
                Console.WriteLine(i*i);
            }
        }
    }
}

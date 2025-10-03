namespace homework9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1
            var barambo = new Company(true);
            var emp1 = new Employee("luka", "vashakidze", 99, "manager", new int [] { 8,8,8,8,8,0,0});
            barambo.AddEmployee(emp1);
            Console.WriteLine(barambo.CalculateTax());
            var emp2 = new Employee("some", "guy", 42, "CTO", new int[] { 6, 3, 3, 1, 2, 4, 0, 0 });
            barambo.AddEmployee(emp2);
            Console.WriteLine(barambo.CalculateTax());

            var apple = new Company(false);
            var emp3 = new Employee("steve", "jobs", 99999999, "developer", new int[] { 8,8,8,9,9,0,0});
            apple.AddEmployee(emp2);
            Console.WriteLine(apple.CalculateTax());


            //task2

            var student1 = new Student("luka", 19, 2022);
            Console.WriteLine(student1.yearsLeft());
            student1.randomSubject();
            var teacher1 = new Teacher("nana", true);
            teacher1.check("Math");


        }

    }
}

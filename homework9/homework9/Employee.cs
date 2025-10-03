using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace homework9
{
    internal class Employee
    {
        private string firstName;
        private string lastName;
        private int age;
        public string position;
        private int[] weeklyHours;

        public Employee(string firstName, string lastName, int age, string position, int[] weeklyHours)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.position = position;
            this.weeklyHours = weeklyHours;

        }
        public double Salary()
        {
            double salary = 0;
            int totalHours = 0;
            double rate = baseRate(position); 

            for (int i = 0; i < weeklyHours.Length; i++)
            {
                if (i >= 0 && i < 5)
                    if (weeklyHours[i] > 8)
                    {
                        salary += (8 * rate) + ((weeklyHours[i] - 8) * (rate + 5));
                    }
                    else
                    {
                        salary += weeklyHours[i] * rate;
                    }
                else if (i >= 5 && i <= 6)
                {
                    salary += weeklyHours[i] * rate * 2;
                }
                totalHours += weeklyHours[i];
            }
            if (totalHours > 50)
            {
                salary *= 1.2;
            }

            Console.WriteLine("total weekly salary is: " + salary);
       
            return salary;
        }
        public double baseRate(string position)
        {
            switch (position) {
                case "manager":
                    return 40;
                case "tester":
                    return 20;
                case "developer":
                    return 30;
                default:
                    return 10;
            }
        }
    }
}

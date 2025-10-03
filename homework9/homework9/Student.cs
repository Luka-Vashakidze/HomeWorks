using System;
using System.Runtime.InteropServices.JavaScript;

namespace homework9
{
    internal class Student
    {
        Random rnd = new Random();
        private string name;
        private int age;
        private int yearAccepted;
        public string[] subjects = { "Math", "Physics", "Chemistry", "English", "Programming" };

        public Student(string name, int age, int yearAccepted)
        {
            this.name = name;
            this.age = age;
            this.yearAccepted = yearAccepted;
        }

        public string randomSubject()
        {
            int randomIndex = rnd.Next(0, subjects.Length);
            return subjects[randomIndex];
        }

        public int yearsLeft()
        {
            return (yearAccepted + 4) - 2025;
        }
    }

    
}
internal class Teacher
{
    private static Random rnd = new Random();

    private string name;
    private bool isCertified;

    public Teacher(string name, bool isCertified)
    {
        this.name = name;
        this.isCertified = isCertified;
    }

    public void check(string subject)
    {


        if (subject == "Math")
        {
            int a = rnd.Next(1, 22);
            int b = rnd.Next(1, 22);
            Console.WriteLine($"Math - {a} + {b} = {a + b}");
        }
        else if (subject == "Chemistry")
        {
            Console.WriteLine($" Chemistry -  H2O");
        }
        else if (subject == "English")
        {
            Console.WriteLine($"English - keep learning");
        }
        else
        {
            Console.WriteLine($"not competent in  + {subject}");
        }
    }
}
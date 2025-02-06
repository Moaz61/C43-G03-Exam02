using System.Diagnostics;

namespace AnsExam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub = new Subject(10, "C#");
            sub.CreateExam();
            Console.Clear();
            Console.Write("Do you want to start exam (y || n)? ");
            if (char.Parse(Console.ReadLine().ToLower()) == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sub.Exam.ShowExam();
                Console.WriteLine($"Time taken: {sw.Elapsed}");
            }
        }
    }
}

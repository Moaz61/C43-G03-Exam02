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
            bool validInput = false;
            do
            {
                Console.Write("Do you want to start exam (y || n)? ");
                string input = Console.ReadLine()?.ToLower();

                if (input == "y" || input == "n")
                {
                    if (input == "y")
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        sub.Exam.ShowExam();
                        Console.WriteLine($"Time taken: {sw.Elapsed}");
                    }
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input Please enter 'y' or 'n'");
                }

            } while (!validInput);
        }
    }
}

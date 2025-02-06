using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsExam2.ExamForm;
using AnsExam2.ExamQuestions;

namespace AnsExam2
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; private set; }

        public Subject(int id , String name)
        {
            this.SubjectId = id;
            this.SubjectName = name;
        }
        public void CreateExam() 
        {
            int examType, numQuestions, duration;

            do
            {
                Console.Write("Enter exam type (1 for Final, 2 for Practical): ");
                if (int.TryParse(Console.ReadLine(), out examType) && (examType == 1 || examType == 2))
                    break;
                Console.WriteLine("Invalid input please enter 1 or 2");
            } while (true);

            do
            {
                Console.Write("Enter number of questions: ");
                if (int.TryParse(Console.ReadLine(), out numQuestions) && numQuestions > 0)
                    break;
                Console.WriteLine("Invalid input please enter a positive number");
            } while (true);

            do
            {
                Console.Write("Enter exam duration (minutes): ");
                if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
                    break;
                Console.WriteLine("Invalid input please enter a positive number");
            } while (true);

            TimeSpan timeSpan = TimeSpan.FromMinutes(duration);

            if (examType == 1)
            {
                Exam = new FinalExam(timeSpan, numQuestions);
            }

            else
            {
                Exam = new PracticalExam(timeSpan, numQuestions);

                //for(int i = 0; i < numQuestions; i++)
                //{
                //    Console.Clear();
                //    Console.WriteLine($"Enter details for Question {i + 1}:");
                //    Console.Write("Choose type (1 for MCQ): ");
                //    int questionType = int.Parse(Console.ReadLine());

                //    Console.Write("Enter question body: ");
                //    string body = Console.ReadLine();

                //    Console.Write("Enter question mark: ");
                //    double mark = double.Parse(Console.ReadLine());

                //    Question question;
                //    if (questionType == 1)
                //    {
                //        question = new MCQMultilpeChoice($"Q{i + 1} (MCQ)", body, mark);
                //        for (int j = 0; j < 3; j++)
                //        {
                //            Console.Write($"Enter choice {j + 1}: ");
                //            string answerText = Console.ReadLine();
                //            question.AnswerList.Add(new Answer(j + 1, answerText));
                //        }
                //        Console.Write("Enter correct answer number: ");
                //        int correctAnswer = int.Parse(Console.ReadLine());
                //        question.RightAnswer = question.AnswerList[correctAnswer - 1];
                //    }

                //    Exam.Questions.Add(question);
                //}
            }

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine($"Enter details for Question {i + 1}:");
                Console.Write("Choose type (1 for True/False, 2 for MCQ): ");
                int questionType = int.Parse(Console.ReadLine());

                Console.Write("Enter question body: ");
                string body = Console.ReadLine();

                Console.Write("Enter question mark: ");
                double mark = double.Parse(Console.ReadLine());

                Question question;
                if (questionType == 1)
                {
                    question = new TrueFalseQuestion($"Q{i + 1} (True/False)", body, mark);
                    Console.Write("Enter correct answer (1 for True, 2 for False): ");
                    int correctAnswer = int.Parse(Console.ReadLine());
                    question.RightAnswer = question.AnswerList[correctAnswer - 1];
                }
                else
                {
                    question = new MCQOneChoice($"Q{i + 1} (MCQ)", body, mark);
                    for (int j = 0; j < 3; j++) 
                    {
                        Console.Write($"Enter choice {j + 1}: ");
                        string answerText = Console.ReadLine();
                        question.AnswerList.Add(new Answer(j + 1, answerText));
                    }
                    Console.Write("Enter correct answer number: ");
                    int correctAnswer = int.Parse(Console.ReadLine());
                    question.RightAnswer = question.AnswerList[correctAnswer - 1];
                }

                
                Exam.Questions.Add(question);
            }

            Console.Clear();
        }
    }
}

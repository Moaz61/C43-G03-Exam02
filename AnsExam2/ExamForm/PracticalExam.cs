using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsExam2.ExamQuestions;

namespace AnsExam2.ExamForm
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(TimeSpan time, int numofque) : base(time, numofque)
        {
        }

        public override void ShowExam()
        {
            int userAnswer;
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                }

                do
                {
                    Console.Write("Your answer: ");
                }
                while (!int.TryParse(Console.ReadLine(), out userAnswer));

                Console.WriteLine($"Correct answer was: {question.RightAnswer.AnswerText}\n");
            }
        }
    }
}

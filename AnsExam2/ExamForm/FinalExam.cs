using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsExam2.ExamForm
{
    internal class FinalExam : Exam
    {
        public FinalExam(TimeSpan time, int numofque) : base(time, numofque)
        { 
        }

        public override void ShowExam()
        {
            int userAnswer;
            double TotalMark = 0;
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine($"{answer.AnswerId} , {answer.AnswerText}");
                };
                do
                {
                    Console.WriteLine("Your answer: ");
                }
                while(int.TryParse(Console.ReadLine(), out userAnswer));

                if (question.AnswerList.Find(ans => ans.AnswerId == userAnswer) == question.RightAnswer)
                {
                    TotalMark += question.Mark;
                }
            }
            Console.WriteLine($"\nYour grade is: {TotalMark}");
        }
    }
}

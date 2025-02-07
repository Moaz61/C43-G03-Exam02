using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsExam2.ExamQuestions
{
    internal class MCQChoice : Question
    {
        public MCQChoice(string body, double mark , List<Answer> AnswerList, Answer RightAnswer) : base("MCQ Question", body, mark ,AnswerList, RightAnswer )
        {
        }

        public override string ToString()
        {
            return $"\nMultiple Choice Question: {Body}            Mark: {Mark}";
        }
    }
}

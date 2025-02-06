using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsExam2.ExamQuestions
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, double mark) : base(header, body, mark)
        {
            AnswerList.Add(new Answer(1, "True"));
            AnswerList.Add(new Answer(2, "False"));
        }

        public override object Clone()
        {
            return new TrueFalseQuestion(this.Header, this.Body, this.Mark);
        }
    }
}

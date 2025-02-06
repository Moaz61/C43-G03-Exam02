using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsExam2.ExamQuestions
{
    internal class MCQMultilpeChoice : Question
    {
        public MCQMultilpeChoice(string header, string body, double mark) : base(header, body, mark)
        {
        }

        public override object Clone()
        {
            return new MCQMultilpeChoice(this.Header, this.Body, this.Mark);
        }
    }
}

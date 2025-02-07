using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsExam2.ExamQuestions
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, double mark, Answer RightAnswer) : base("True or False Question", body, mark, new List<Answer> { new Answer(1, "True"), new Answer(2, "False") }, RightAnswer)
        {
        }

        public override string ToString()
        {
            return $"\nTrue/False Question: {Body}             Mark: {Mark}";
        }
    }
}

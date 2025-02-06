using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsExam2.ExamQuestions
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header {  get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer RightAnswer { get; set; }


        public Question(String header , String body , double mark) 
        {
            this.Header = header;
            this.Body = body;
            this.Mark = mark;
            AnswerList = new List<Answer>();
        }
        public abstract object Clone();
        public int CompareTo(Question? other)
        {
            return this.Mark.CompareTo(other?.Mark);
        }
        public override string ToString()
        {
            return $"Header: {Header}\nBody: {Body}\nMark: {Mark}";
        }
    }
}

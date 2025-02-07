using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsExam2.ExamQuestions
{
    internal abstract class Question
    {
        public string Header {  get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer RightAnswer { get; set; }


        public Question(String header , String body , double mark , List<Answer> AnswerList , Answer RightAnswer) 
        {
            this.Header = header;
            this.Body = body;
            this.Mark = mark;
            this.AnswerList = AnswerList;
            this.RightAnswer = RightAnswer;
        }

        public abstract override string ToString();
        
    }
}

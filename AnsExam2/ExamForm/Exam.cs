using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsExam2.ExamQuestions;

namespace AnsExam2.ExamForm
{
    internal abstract class Exam
    {
        public TimeSpan Time {  get; set; }
        public int NumberOfQuestions {  get; set; }
        public List<Question> Questions { get; set; }
        public Exam(TimeSpan time , int numofque , List<Question> questions)
        {
            this.Time = time;
            this.NumberOfQuestions = numofque;
            this.Questions = questions;
        }

        public abstract void ShowExam();
    }
}

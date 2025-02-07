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
            List<Question> questions = new List<Question>();

            if (examType == 1)
            {
                for (int i = 0; i < numQuestions; i++)
                {
                    Console.Clear();
                    int questionType;
                    do
                    {
                        Console.Write("Choose type (1 for True/False, 2 for MCQ): ");
                    } while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2));

                    string body;
                    do
                    {
                        Console.Write("Enter question body: ");
                        body = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(body));

                    double mark;
                    do
                    {
                        Console.Write("Enter question mark: ");
                    } while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                    if (questionType == 1)
                    {
                        int correctAnswer;
                        do
                        {
                            Console.Write("Enter correct answer (1 for True, 2 for False): ");
                        } while (!int.TryParse(Console.ReadLine(), out correctAnswer) || (correctAnswer != 1 && correctAnswer != 2));

                        string correctAnswerTxt = correctAnswer == 1 ? "True" : "False";

                        Answer RightAnswer = new Answer(correctAnswer, correctAnswerTxt);

                        TrueFalseQuestion trueFalseQuestion = new TrueFalseQuestion(body, mark, RightAnswer);

                        questions.Add(trueFalseQuestion);
                    }
                    else
                    {
                        List<Answer> answerList = new List<Answer>();

                        for (int j = 0; j < 3; j++)
                        {
                            string answerText;
                            do
                            {
                                Console.Write($"Enter choices {j + 1}: ");
                                answerText = Console.ReadLine();
                            }while (string.IsNullOrWhiteSpace(answerText));

                            Answer choicesID = new Answer(j + 1, answerText);

                            answerList.Add(choicesID);
                        }
                        int correctAnswer;
                        do
                        {
                            Console.Write("Enter correct answer number (1, 2, or 3): ");
                        } while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 3);

                        string RightAnswerTxt = answerList[correctAnswer - 1].AnswerText;

                        Answer answer = new Answer(correctAnswer, RightAnswerTxt);

                        MCQChoice MCQ = new MCQChoice(body, mark, answerList, answer);

                        questions.Add(MCQ);
                        Console.Clear();
                    }
                }
                Exam = new FinalExam(timeSpan, numQuestions, questions);
            }

            else
            {
                for (int i = 0; i < numQuestions; i++)
                {
                    Console.Clear();

                    string body;
                    do 
                    {
                        Console.Write($"Enter question {i + 1} body: ");
                        body = Console.ReadLine();
                    }while (string.IsNullOrWhiteSpace(body));

                    double mark;
                    do
                    {
                        Console.Write("Enter question mark: ");
                    } while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                    List<Answer> answerList = new List<Answer>();

                    for (int j = 0; j < 3; j++)
                    {
                        string answerTxt;
                        do
                        {
                            Console.Write($"Enter choices {j + 1}: ");
                            answerTxt = Console.ReadLine();
                        }while (string.IsNullOrWhiteSpace(answerTxt));

                        Answer choicesID = new Answer(j + 1, answerTxt);

                        answerList.Add(choicesID);
                    }
                    int correctAnswer;
                    do
                    {
                        Console.Write("Enter correct answer number (1, 2, or 3): ");
                    } while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer < 1 || correctAnswer > 3);

                    String RightAnswerTxt = answerList[correctAnswer - 1].AnswerText;

                    Answer answer = new Answer(correctAnswer, RightAnswerTxt);

                    MCQChoice MCQ = new MCQChoice(body, mark, answerList, answer);

                    questions.Add(MCQ);
                }
                Exam = new PracticalExam(timeSpan, numQuestions, questions);
            }
        }
    }
}

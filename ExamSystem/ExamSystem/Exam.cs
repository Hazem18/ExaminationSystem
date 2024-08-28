using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public abstract class Exam
    {
        
        protected Exam(int time, int numberOfQuestions, Subject subject)
        {
            this.time=time;
            this.numberOfQuestions=numberOfQuestions;
            this.subject=subject;
            examQuestions = new QuestionList();
            studentAnswers = new AnswerList ();  
            examAnswers = new AnswerList();
        }
        protected Exam() { }

        public int time { get; set; } //in minutes
        public int numberOfQuestions { get; set; }
        public int totalMarks { get; set; }
        public Subject subject { get; set; }
        public QuestionList examQuestions { get; set; }
        public AnswerList studentAnswers { get; set; }
        public AnswerList examAnswers { get; set; }

        public abstract bool IsEmpty(List<Exam> examList);
        public abstract bool IsFound(List<Exam> examList, string subject);
        public abstract int CalcScore();
        public abstract int CalcTotalMarks();
        public abstract Exam FindExam(List<Exam> examList,string subject);
        public abstract void ShowExam();

      
    }
}

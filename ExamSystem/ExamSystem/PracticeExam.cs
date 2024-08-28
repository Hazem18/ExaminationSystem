using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    /// <summary>
    /// The 'Practice Exam' class handles the main functionalities of the exam.
    /// </summary>
    public class PracticeExam : Exam
    {

        public PracticeExam(int time, int numberOfQuestions, Subject subject)
         : base(time, numberOfQuestions, subject) 
        {}


        public PracticeExam() { }

        /// <summary>
        /// CalcScore() ----> Returns the student's score in the exam.
        /// ShowExam() ----> To display the exam question and enable the student to answer each one.
        /// ShowAnswers() ----> To diplsay the exam answers after the student ends.
        /// CalcTotalMarks() ----> Returns the total mark of the exam.
        /// FindExam() ----> Searches for the exam by the subject and returns the exam if it's found.
        /// IsFound() ----> Searches for the exam by the subject and returns true if it's found.
        /// IsEmpty() ----> Returns true if the exam's list is empty.
        /// </summary>
        public override int CalcScore()
        {
            int score = 0;
            for (int i = 0; i<numberOfQuestions; i++) 
            {
                if (studentAnswers[i].textAnswer == examAnswers[i].textAnswer)
                    score+=examQuestions[i].mark;
            }
            return score;
        }
        public override void ShowExam()
        {
            Console.WriteLine($"\nSubject name:{subject.subjectName} - Subject code:{subject.subjectCode}.");
            Console.WriteLine($"Time:{time} Minutes.");
            Console.WriteLine($"Total marks: {CalcTotalMarks()}");
            Console.WriteLine("----Practice Exam----");
            for (int i = 0;i<examQuestions.Count;i++)
            {
                
                    examQuestions[i].DisplayQuestion();
                    Console.Write("Your Answer (separate between choices with a space):");
                    string ans = Console.ReadLine() ?? string.Empty;
                    Answer answer = new Answer(ans);
                    studentAnswers.Add(answer);
                
      
            }
        }

        public void ShowAnswers()
        {
            Console.WriteLine("\n--------------Practice Answers--------------");
            for (int i = 0;i< examAnswers.Count;i++)
            {
                Console.WriteLine($"{i+1}-{examAnswers[i].textAnswer}");
            }
            Console.WriteLine("\n------------------------------");
        }

        public override int CalcTotalMarks()
        {
           int sum = 0;
            for(int i = 0;i < examQuestions.Count;i++)
                 sum+= examQuestions[i].mark;
            
            return sum;
        }

        public override Exam FindExam(List<Exam> examList, string subject)
        {
                foreach (Exam exam in examList)
                   if (exam.subject.subjectName == subject)
                         return exam;
                
                return null;
        }

        public override bool IsEmpty(List<Exam> examList)
        {
            if (examList.Count == 0)
                return true;
            else
                return false;
        }
        public override bool IsFound(List<Exam> examList, string subject)
        {
            bool found = false;
            foreach (Exam exam in examList)
            {
                if (exam.subject.subjectName == subject)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public abstract class Question
    {
        protected Question(string header, string body, int mark)
        {
            this.header=header;
            this.body=body;
            this.mark=mark;
            Answers = new AnswerList();
        }

        public string header { get; set; }
        public string body { get; set; }

        public int mark { get; set; }

        public AnswerList Answers { get; set; }


        public abstract void DisplayQuestion();

    }
}

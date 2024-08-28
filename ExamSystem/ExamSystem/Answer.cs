using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public class Answer
    {
        public Answer(string textAnswer = "This is a True and false Question, No choices.", bool iscorrect = false)
        {
            this.textAnswer=textAnswer;
            this.iscorrect=iscorrect;
        }

        public string textAnswer { get; set; }
        public bool iscorrect { get; set; }


    }
}

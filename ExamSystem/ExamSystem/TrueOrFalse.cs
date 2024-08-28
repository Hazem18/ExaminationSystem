using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public class TrueOrFalse : Question
    {
        public TrueOrFalse(bool correctAnswer, int mark ,string body ,string header = "True or False")
            : base (header,body,mark)
        {
            this.correctAnswer=correctAnswer;
        }

        public bool correctAnswer { get; set; }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{header} {mark} Mark(s)\n{body}: ");
        }
    }
}

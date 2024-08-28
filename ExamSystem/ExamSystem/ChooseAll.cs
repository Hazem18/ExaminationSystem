using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public class ChooseAll : Question
    {
        public ChooseAll(string body, int mark, string header = "Choose ALL the correct answers from the following")
            : base(header, body, mark)
        { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{header} {mark} Mark(s)\n{body}: ");
            char ctr = 'A';
            for (int i = 0; i<Answers.Count; i++)
            {
                Console.WriteLine($"{ctr}-{Answers[i].textAnswer}.");
                ctr++;
            }
        }
    }
}

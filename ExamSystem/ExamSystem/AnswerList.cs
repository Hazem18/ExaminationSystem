using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public class AnswerList : List<Answer>
    {
        public void AddAnswer(Answer answer)
            { this.Add(answer); }
    }
}

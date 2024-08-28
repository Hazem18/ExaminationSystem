using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public class QuestionList : List<Question>
    {
        public void AddQuestion(Question question)
        {
            this.Add(question);
        }
    }
}

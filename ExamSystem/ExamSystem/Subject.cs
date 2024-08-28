using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    public class Subject
    {
        public Subject(string subjectName ="" , string subjectCode="")
        {
            this.subjectName=subjectName;
            this.subjectCode=subjectCode;
        }

        public string subjectName { get; set; }
        public string subjectCode { get; set; }
    }
}

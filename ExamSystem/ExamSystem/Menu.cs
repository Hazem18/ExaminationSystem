using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{

    /// <summary>
    /// The menu class is used to display all the menu types in the system
    /// </summary>
    public class Menu
    {

        public static void MainMenu()
        {
            Console.WriteLine("\n-------Welcome-----------");
            Console.WriteLine("\nT-Register as a teacher.");
            Console.WriteLine("\nS-Register as a student.");
            Console.WriteLine("\nQ-Exit.");
            Console.Write("\nChoose the user type:");
        }
        public static void TeacherMenu()
        {
            Console.WriteLine("\nP-Make a practice exam.");
            Console.WriteLine("\nF-Make a practice exam.");
            Console.Write("\nChoose the exam type:");
        }
        public static void StudentMenu()
        {
            Console.WriteLine("\nP-Take a practice exam.");
            Console.WriteLine("\nF-Take a practice exam.");
            Console.Write("\nChoose the exam type:");
        }
        public static void QuestionsMenu(int questionIndex)
        {
            Console.WriteLine("\n1-True-False.");
            Console.WriteLine("\n2-Choose one.");
            Console.WriteLine("\n3-Choose All.");
            Console.Write($"\nChoose the type of question {questionIndex+1}:");
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    /// <summary>
    ///The 'System' class Handels the flow of the system and its different paths
    /// </summary>
    public class System
    {
        public static char UserChoice { get; set; }
        public static List<Exam> examList { get; set; } = new List<Exam>(); //P
        public static List<Exam> examList1 { get; set; } = new List<Exam>(); //F

        /// <summary>
        /// CreatePracticeExam() function includes on the creation process of a practice exam.
        /// CreateFinalExam() function includes on the creation process of a final exam.
        /// ShowPracticeExam() function used to display the practice exam for the student.
        /// ShowFinalExam() function used to display the final exam for the student.
        /// HandleTeacherBehavior() && HandleStudentBehavior() handels the user choices.
        /// Run() is the kick-off of the system.
        /// </summary>
        public static void CreatePracticeExam()
        {
            try
            {
                PracticeExam exam = new PracticeExam();
                int numQuestions;
                int time;

                Console.WriteLine("------------Making Practice exam---------------");
                Console.Write("Enter the subject name: ");
                string subjectName = Console.ReadLine() ?? "General Informations";

                Console.Write("Enter the subject code: ");
                string subjectCode = Console.ReadLine() ?? "Ge-101";
                Subject subject = new Subject(subjectName, subjectCode);

                Console.Write("Enter the number of questions: ");
                string? input1 = Console.ReadLine();
                numQuestions = string.IsNullOrEmpty(input1) ? 3 : int.Parse(input1);

                Console.Write("Enter the exam time limit: ");
                string? input2 = Console.ReadLine();
                time = string.IsNullOrEmpty(input2) ? 30 : int.Parse(input2);

                exam = new PracticeExam(time, numQuestions, subject);
                Console.WriteLine("\n-----Add Questions-------");

                for (int i = 0; i < numQuestions; i++)
                {
                    char questionChoice = '\0';
                    Menu.QuestionsMenu(i);
                    string? input3 = Console.ReadLine();
                    questionChoice = string.IsNullOrEmpty(input3) ? '1' : char.Parse(input3);

                    if (questionChoice == '1')
                    {
                        int mark = 1;
                        Console.Write($"Enter the body of question {i + 1}: ");
                        string body = Console.ReadLine() ?? "No body";

                        Console.Write($"Enter the mark of question {i + 1}: ");
                        string? input4 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input4))
                            mark = int.Parse(input4);

                        Console.Write($"Enter the correct answer(s) of question {i + 1} (t/f): ");
                        string correctAnswer = Console.ReadLine() ?? string.Empty;

                        TrueOrFalse question = new TrueOrFalse(true, mark, body);
                        Answer answer = new Answer(correctAnswer);

                        exam.examQuestions.Add(question);
                        exam.examAnswers.Add(answer);
                    }
                    else if (questionChoice == '2')
                    {
                        int mark = 1;
                        int numChoices = 4;
                        Console.Write($"Enter the body of question {i + 1}: ");
                        string body = Console.ReadLine() ?? "No body";

                        Console.Write($"Enter the mark of question {i + 1}: ");
                        string? input4 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input4))
                            mark = int.Parse(input4);

                        ChooseOne question = new ChooseOne(body, mark);
                        Console.WriteLine("\n----------Add answers (choices) for the question----------");
                        Console.Write("\nEnter number of choices: ");
                        string? input5 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input5))
                            numChoices = int.Parse(input5);

                        for (int j = 0; j < numChoices; j++)
                        {
                            Console.Write($"Choice {j + 1}: ");
                            string c = Console.ReadLine() ?? "Empty answer";
                            Answer answer1 = new Answer(c);
                            question.Answers.Add(answer1);
                        }
                        Console.WriteLine("------------Answers Added----------");

                        Console.Write($"Enter the correct answer(s) of question {i + 1} (a,b,c,d,....): ");
                        string correctAnswer = Console.ReadLine() ?? string.Empty;
                        Answer answer = new Answer(correctAnswer);

                        exam.examQuestions.Add(question);
                        exam.examAnswers.Add(answer);
                    }
                    else if (questionChoice == '3')
                    {
                        int mark = 1;
                        int numChoices = 4;
                        Console.Write($"Enter the body of question {i + 1}: ");
                        string body = Console.ReadLine() ?? "No body";

                        Console.Write($"Enter the mark of question {i + 1}: ");
                        string? input4 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input4))
                            mark = int.Parse(input4);

                        ChooseAll question = new ChooseAll(body, mark);
                        Console.WriteLine("\n----------Add answers (choices) for the question----------");
                        Console.Write("\nEnter number of choices: ");
                        string? input5 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input5))
                            numChoices = int.Parse(input5);
                        for (int j = 0; j < numChoices; j++)
                        {
                            Console.Write($"Choice {j + 1}: ");
                            string c = Console.ReadLine() ?? "Empty answer";
                            Answer answer1 = new Answer(c);
                            question.Answers.Add(answer1);
                        }
                        Console.WriteLine("------------Answers Added----------");

                        Console.Write($"Enter the correct answer(s) of question {i + 1} (separate between choices with a space), (a,b,c,d,....): ");
                        string correctAnswer = Console.ReadLine() ?? string.Empty;
                        Answer answer = new Answer(correctAnswer);

                        exam.examQuestions.Add(question);
                        exam.examAnswers.Add(answer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice...Try again");
                    }
                }

                examList.Add(exam);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input format is not correct: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public static void CreatefinalExam()
        {
            try
            {
                int numQuestions;
                int time;
                FinalExam exam = new FinalExam();
                Console.WriteLine("\n------------Making Final exam---------------");
                Console.Write("\nEnter the subject name:");
                string subjectName = Console.ReadLine() ?? "General informations";

                Console.Write("\nEnter the subject code:");
                string subjectCode = Console.ReadLine() ?? "Ge-101";
                Subject subject = new Subject(subjectName, subjectCode);

                Console.Write("\nEnter the number of questions:");
                string? input1 = Console.ReadLine();
                if (string.IsNullOrEmpty(input1))
                    numQuestions = 3;
                else
                    numQuestions = int.Parse(input1);

                Console.Write("\nEnter the exam time limit:");
                string? input2 = Console.ReadLine();
                if (string.IsNullOrEmpty(input2))
                    time = 30;
                else
                    time = int.Parse(input2);


                exam = new(time, numQuestions, subject);

                Console.WriteLine("\n-----Add Questions-------");

                for (int i = 0; i<numQuestions; i++)
                {
                    char questionChoice = '\0';
                    Menu.QuestionsMenu(i);

                    string? input3 = Console.ReadLine();
                    if (string.IsNullOrEmpty(input3))
                        questionChoice = '1';
                    else
                        questionChoice = char.Parse(input3);

                    if (questionChoice == '1')
                    {
                        int mark = 1; // Default
                        Console.Write($"Enter the body of question {i+1}:");
                        string body = Console.ReadLine() ?? "No body ";

                        Console.Write($"Enter the mark of question {i+1}:");
                        string? input4 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input4))
                            mark = int.Parse(input4);

                        Console.Write($"Enter the correct answer(s) of question {i+1}:");
                        string correctAnswer = Console.ReadLine()??string.Empty;

                        TrueOrFalse question = new(true, mark, body);
                        Answer answer = new(correctAnswer);

                        exam.examQuestions.Add(question);
                        exam.examAnswers.Add(answer);
                    }

                    else if (questionChoice == '2')
                    {
                        int mark = 1;//default
                        int numChoices = 4;//default;
                        Console.Write($"Enter the body of question {i+1}:");
                        string body = Console.ReadLine() ?? "No body";

                        Console.Write($"Enter the mark of question {i+1}:");
                        string? input4 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input4))
                            mark = int.Parse(input4);

                        ChooseOne question = new(body, mark);
                        /////////////////////////////////////////////
                        Console.WriteLine("\n----------Add answers (choices) for the questions----------");
                        Console.Write("\nEnter number of choices:");
                        string? input5 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input5))
                            numChoices = int.Parse(input5);

                        for (int j = 0; j<numChoices; j++)
                        {
                            Console.Write($"Choice {j+1}:");
                            string c = Console.ReadLine()??"Empty answer";
                            Answer answer1 = new(c);
                            question.Answers.Add(answer1);
                        }
                        Console.WriteLine("------------Answers Added----------");
                        ///////////////////////////////////////////////////

                        Console.Write($"Enter the correct answer(s) of question {i+1}:");
                        string correctAnswer = Console.ReadLine()??string.Empty;
                        Answer answer = new(correctAnswer);


                        exam.examQuestions.Add(question);
                        exam.examAnswers.Add(answer);

                    }

                    else if (questionChoice == '3')
                    {
                        int mark = 1;//default
                        int numChoices = 4;//default
                        Console.Write($"Enter the body of question {i+1}:");
                        string body = Console.ReadLine() ??"No body";

                        Console.Write($"Enter the mark of question {i+1}:");
                        string? input4 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input4))
                            mark = int.Parse(input4);

                        ChooseAll question = new(body, mark);
                        /////////////////////////////////////////////
                        Console.WriteLine("\n----------Add answers (choices) for the questions----------");
                        Console.Write("\nEnter number of choices:");
                        string? input5 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input5))
                            numChoices = int.Parse(input5);
                        for (int j = 0; j<numChoices; j++)
                        {
                            Console.Write($"Choice {j+1}:");
                            string c = Console.ReadLine()??"Empty answer";
                            Answer answer1 = new(c);
                            question.Answers.Add(answer1);
                        }
                        Console.WriteLine("------------Answers Added----------");
                        ///////////////////////////////////////////////////

                        Console.Write($"Enter the correct answer(s) of question {i+1} (separate between choices with a space):");
                        string correctAnswer = Console.ReadLine()??string.Empty;
                        Answer answer = new(correctAnswer);
                        exam.examQuestions.Add(question);
                        exam.examAnswers.Add(answer);
                    }
                    else
                        Console.WriteLine("Invalid Choice...Try again");
                }

                examList1.Add(exam);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input format is not correct: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
       public static void ShowPracticeExam()
        {
            PracticeExam exam = new PracticeExam();
            if (exam.IsEmpty(examList))
                Console.WriteLine("No exams available now...");

            else
            {
                Console.WriteLine("Enter the subject name: ");
                string subjectName = Console.ReadLine()  ?? "General informations";
                if (exam.IsFound(examList, subjectName))
                {
                    exam = (PracticeExam)exam.FindExam(examList, subjectName);
                    exam.ShowExam();
                    exam.ShowAnswers();
                    Console.WriteLine($"\nYour score: {exam.CalcScore()} / {exam.CalcTotalMarks()}");
                }
                else
                    Console.WriteLine($"\nNo exams found for the subject {subjectName}");
            }
        }
        public static void ShowfinalExam()
        {
            FinalExam exam = new FinalExam();
            if (exam.IsEmpty(examList1))
                Console.WriteLine("\nNo exams available now...");

            else
            {
                Console.WriteLine("\nEnter the subject name: ");
                string subjectName = Console.ReadLine() ?? "General informations";
                if (exam.IsFound(examList1, subjectName))
                {
                    exam = (FinalExam)exam.FindExam(examList1, subjectName);
                    exam.ShowExam();
                    Console.WriteLine($"\nYour score: {exam.CalcScore()} / {exam.CalcTotalMarks()}");
                }
                else
                    Console.WriteLine($"\nNo exams found for the subject {subjectName}.");
            }
        }
        public static void HandleTeacherBehavior()
        {
            char examChoice = '\0';
            Menu.TeacherMenu();
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
                examChoice = char.Parse(input);
            else
                Console.WriteLine("\nInvalid...Null value");

            if (examChoice == 'P' || examChoice == 'p')
                System.CreatePracticeExam();

            else if (examChoice == 'F' || examChoice == 'f')
                System.CreatefinalExam();
        }
        public static void HandleStudentBehavior()
        {
            char examChoice = '\0';
            Menu.StudentMenu();
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
                 examChoice = char.Parse(input);
            else
                Console.WriteLine("\nInvalid...Null value");

            if (examChoice == 'p' || examChoice == 'P')
                System.ShowPracticeExam();

            else if (examChoice == 'f' || examChoice == 'F')
                System.ShowfinalExam();

            else
                Console.WriteLine("Invalid Choice...Try again");
        }
        public static void Run()
        {
            do
            {
                Menu.MainMenu();

                string? input = Console.ReadLine();
                if(!string.IsNullOrEmpty(input))
                    UserChoice = char.Parse(input);
                else
                    Console.WriteLine("\nInvalid...Null value");



                switch (UserChoice)
                {
                    case 'T':
                    case 't':
                            HandleTeacherBehavior(); break;
                    case 's':
                    case 'S':
                            HandleStudentBehavior(); break;
                    case 'q':
                    case 'Q':
                            Console.WriteLine("\nThank You!!----Bye Bye"); break;
                    default:
                        Console.WriteLine("\nInvalid Choice...Try again"); break;
                }
            } while (UserChoice != 'Q' && UserChoice != 'q');

        }

      
    }
}

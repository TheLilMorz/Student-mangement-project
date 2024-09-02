using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var CollegeStudents =new List<CollegeStudent>();

            while (true)
            {
                Console.WriteLine("Would you like to manage a student or a college student?");
                string studentType = Console.ReadLine().ToLower();

                if (studentType == "student")
                {
                    Console.WriteLine("What would you like to do (add, change info, or show info)?");
                    string action = Console.ReadLine().ToLower();

                    if (action == "add")
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter the student's name:");
                            string studentName = Console.ReadLine();

                            Console.WriteLine("Enter the student's ID:");
                            int studentID = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the student's age:");
                            int studentAge = int.Parse(Console.ReadLine());

                            students.Add(new Student(studentName, studentID, studentAge));
                            Console.WriteLine("Student was added successfully. Would you like to add another one (yes or no)?");
                            string keepGoing = Console.ReadLine().ToLower();

                            if (keepGoing == "no")
                                break;
                            else if (keepGoing != "yes")
                            {
                                Console.WriteLine("Unclear response. Not adding another student.");
                                break;
                            }
                        }
                    }
                    else if (action == "change info")
                    {
                        Console.WriteLine("Enter the student's ID whose info you want to change:");
                        int studentID = int.Parse(Console.ReadLine());

                        Student student = students.Find(s => s.StudentID == studentID);
                        if (student != null)
                        {
                            Console.WriteLine("Enter the new name (or press Enter to keep the current name):");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newName))
                            {
                                student.StudentName = newName;
                            }

                            Console.WriteLine("Enter the new age (or press Enter to keep the current age):");
                            string newAgeInput = Console.ReadLine();
                            if (int.TryParse(newAgeInput, out int newAge))
                            {
                                student.Age = newAge;
                            }

                            Console.WriteLine("Student information updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else if (action == "show info")
                    {
                        Console.WriteLine("Enter the student's ID to view their information:");
                        int studentID = int.Parse(Console.ReadLine());

                        Student student = students.Find(s => s.StudentID == studentID);
                        if (student != null)
                        {
                            student.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid action.");
                    }
                }
                else if (studentType == "college student")
                {
                    System.Console.WriteLine("What would you like to do (add, change info, show info): ");
                    string action = Console.ReadLine();

                    if (action.ToLower() == "add")
                    {
                        while (true)
                        {
                            System.Console.WriteLine("Enter student's name: ");
                            string Student_Name = Console.ReadLine();
                            System.Console.WriteLine("Enter student ID: ");
                            int Student_ID = int.Parse(Console.ReadLine());
                            System.Console.WriteLine("Enter student's age: ");
                            int Student_Age = int.Parse(Console.ReadLine());
                            System.Console.WriteLine("Enter the student's subject: ");
                            string subject = Console.ReadLine();
                            System.Console.WriteLine("Enter studnet's average: ");
                            int avg = int.Parse(Console.ReadLine());
                            
                            CollegeStudents.Add(new CollegeStudent(Student_Name, Student_ID, Student_Age, subject, avg));

                            Console.WriteLine("Student was added successfully. Would you like to add another one (yes or no)?");
                            string keepGoing = Console.ReadLine().ToLower();

                            if (keepGoing == "no")
                                break;
                            else if (keepGoing != "yes")
                            {
                                Console.WriteLine("Unclear response. Not adding another student.");
                                break;
                            }

                        }
                    }
                    else if(action.ToLower() == "change info")
                    {
                        while (true)
                        {
                            System.Console.WriteLine("Enter the studnet's ID whose info you would like to change: ");
                            int SearchID = int.Parse(Console.ReadLine());

                            CollegeStudent Cstudent =CollegeStudents.Find(s=> s.StudentID == SearchID);

                            if (Cstudent != null)
                            {
                                Console.WriteLine("Enter the new name (or press Enter to keep the current name):");
                                string newName = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(newName))
                                {
                                    Cstudent.StudentName = newName;
                                }

                                Console.WriteLine("Enter the new age (or press Enter to keep the current age):");
                                string newAgeInput = Console.ReadLine();

                                if (int.TryParse(newAgeInput, out int newAge))
                                {
                                    Cstudent.Age = newAge;
                                }

                                System.Console.WriteLine("Enter the new subject (or press Enter to keep the current subject): ");
                                string NewSubject = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(NewSubject))
                                {
                                    Cstudent.Subject = NewSubject;
                                }
                                Console.WriteLine("Student information updated successfully.");
                            }
                            else
                            {
                                System.Console.WriteLine("Student not found ");
                            }
                            
                            System.Console.WriteLine("Would you like to stop changing info (yes or no): ");
                            string GoOn = Console.ReadLine();
                            
                            if (GoOn == "no")
                                 break;
                            else if (GoOn == "yes"){}
                           
                            else
                            {
                                Console.WriteLine("Unclear response. Not changing more info.");
                                break;
                            }
                        }
                    }
                    else if (action.ToLower() == "show info")
                    {
                        Console.WriteLine("Enter the student's ID to view their information:");
                        int SearchID = int.Parse(Console.ReadLine());

                        CollegeStudent Cstudent =CollegeStudents.Find(s=> s.StudentID == SearchID);

                        if (Cstudent != null)
                        {
                            Cstudent.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid student type.");
                }
                Console.WriteLine("Would you like to continue or exit: ");
                string response = Console.ReadLine();

                if (response.ToLower() == "exit")
                {
                    Console.WriteLine("Thank you for using our services! Shutting down...");
                    break;
                }
                else if (response.ToLower() != "continue")
                {
                    Console.WriteLine("Invalid response. Exiting program...");
                    break;
                }
            }
        }
    }
    public class Student : IPerson
    {
        protected string studentname;
        protected int studentid;
        protected int age;

        public string StudentName
        {
            get {return studentname;}
            set {studentname = value;}
        }
        
        public int StudentID
        {
            get {return studentid;}
            set {studentid = value;}
        }
        public int Age
        {
            get {return age;}
            set {age = value;}
        }
        

        public Student(string StudentName, int StudentID, int Age)
        {
            this.Age = Age;
            this.StudentID = StudentID;
            this.StudentName = StudentName;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Student name: {this.StudentName} Student ID: {this.StudentID} Age: {this.Age}");
        }
        public Tuple<string, int, int> GetStudentInfo()
        {
            var studentTuple = new Tuple<string, int, int>(StudentName, StudentID, Age);
            return studentTuple;
        }
    }
    public class CollegeStudent : Student,IPerson
    {
        protected string subject {get; set;}
        public string Subject
        {
            get {return subject;}
            set {subject = value;}
        }
        protected int avg {get; set;}
        public int Avg
        {
            get {return avg;}
            set {avg = value;}
        }


    public CollegeStudent(string studentName, int studentID, int age, string subject, int avg) : base(studentName, studentID, age)  
    {
        this.Subject = subject;
        this.Avg = avg;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Student name: {StudentName} Student ID: {StudentID} Age: {Age} Subject {Subject} Average {Avg}");
    }

    }
    public interface IPerson
    {
        void DisplayInfo();
    }
}
using System;
using System.Linq;

namespace ClassroomDBLab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClassContext context = new ClassContext())
            {
                //CreateDB.CreateStudent("Yash", "Maggi", "Detroit");  -- added to db

                //extra - ask user for new student input

                Console.WriteLine("Current Student List: ");
                DisplayAllDB(context);

                bool addStudent = Validator.Validator.Repeat("Would you like to add a student to the DB?");

                while (addStudent)
                {
                    Console.Write("Please enter a student name: ");
                    string name = Validator.Validator.GetString("name");
                    Console.Write("Please enter student favorite food: ");
                    string favFood = Validator.Validator.GetString("fav food");
                    Console.Write("Please enter student hometown: ");
                    string hometown = Validator.Validator.GetString("food");

                    CreateDB(context, name, favFood, hometown);
                    Console.WriteLine("----------------------------------");

                    addStudent = Validator.Validator.Repeat("Would you like to add another student?");
                    Console.Clear();
                }

                Console.WriteLine("Current Student List: ");
                DisplayAllDB(context);

                bool dispStudentDB = Validator.Validator.Repeat("Would you like to learn more about a student?");

                while (dispStudentDB)
                {
                    DisplayStudentDB(context);
                    dispStudentDB = Validator.Validator.Repeat("Would you like to keep learning?");
                }
            }
        }



        public static void CreateDB(ClassContext context, string name, string favFood, string hometown)
        {
            Student student = new Student();
            student.Name = name;
            student.Food = favFood;
            student.Hometown = hometown;

            context.Students.Add(student);

            context.SaveChanges();

            Console.WriteLine("DB has been updated.");
        }


        public static void DisplayAllDB(ClassContext context)
        {
            foreach (Student s in context.Students)
            {
                Console.WriteLine($"{s.StudentId}. {s.Name}");
            }
        }

        public static void DisplayStudentDB(ClassContext context)
        {
            Console.Write("Please enter a student ID: ");
            int answer = Validator.Validator.GetInt(1, context.Students.Count(s => s.StudentId > 0));

            Student student = context.Students.Single(s => s.StudentId == answer);
            Console.WriteLine($"\n{student.Name}'s favorite food is {student.Food} and they are from {student.Hometown}.");
        }
    }
}
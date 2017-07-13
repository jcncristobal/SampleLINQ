using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLINQ
{

    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }

    public class StudentGrades
    {
        public int Science { get; set; }
        public int Math { get; set; }
        public int StudentID { get; set; }
    }


    // Create a data source by using a collection initializer.

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start ");
            List<Student> allStudents = GetStudents();

            SelectOne(allStudents);
            WhereNullContainsType(allStudents);
            PagingOrder(allStudents);
            JoinShapeDistinct(allStudents);
            GroupCountSumProjection(allStudents);
            CompositeOuterJoin(allStudents);
            Insert(allStudents);
            Update(allStudents);
            Delete(allStudents);

            
            Console.ReadKey();
        }

        private static void Delete(List<Student> allStudents)
        {
            throw new NotImplementedException();
        }

        private static void Update(List<Student> allStudents)
        {
            throw new NotImplementedException();
        }

        private static void Insert(List<Student> allStudents)
        {
            throw new NotImplementedException();
        }

        private static void CompositeOuterJoin(List<Student> allStudents)
        {
            throw new NotImplementedException();
        }

        private static void GroupCountSumProjection(List<Student> allStudents)
        {
            throw new NotImplementedException();
        }

        private static void JoinShapeDistinct(List<Student> allStudents)
        {
            throw new NotImplementedException();
        }

        private static void PagingOrder(List<Student> allStudents)
        {
            //Using ID in descending order, with pagination of 10 items per page, on 5th page
            var students = (from sortedStudents in allStudents
                            orderby sortedStudents.ID ascending
                            select sortedStudents).Take(10).Skip(5);

            foreach (var student in students)
            {
                Console.WriteLine("PagingOrder: {0} {1} ID:{2}", student.First, student.Last, student.ID.ToString());

            }

        }

        private static void WhereNullContainsType(List<Student> allStudents)
        {
            //Select student where ID is 114 or student that are absent
            List<int> absentStudents = new List<int> {
                111,
                112,
                113
                };

            var students = from student in allStudents
                           where student.ID == 114 || absentStudents.Contains(student.ID)
                           select student;

            foreach (var student in students)
            {
                Console.WriteLine("WhereNullContainsType 114 or absent: {0} {1} ID:{2}", student.First, student.Last, student.ID.ToString());

            }

        }

        private static void SelectOne(List<Student> allStudents)
        {
            //using long LINQ
            var studentWithID111 = (from student in allStudents
                                    where student.ID == 111
                                    select student).Take(1);

            foreach (var student in studentWithID111)
            {
                Console.WriteLine("Student with ID 111: {0} {1}", student.First, student.Last);

            }

            //using LINQ collection functions
            var fstudentWithID11 = allStudents.FirstOrDefault(student => student.ID.Equals(111));
              Console.WriteLine("Using function FirstOrDefault Student with ID 111: {0} {1}", fstudentWithID11.First, fstudentWithID11.Last);

            
            //using Lambda expression
            var lstudentWithID11 = (from student in allStudents.Where(student => student.ID == 111)
                                    select student).Take(1);

            foreach (var student in lstudentWithID11)
            {
                Console.WriteLine("Using where lambda Student with ID 111: {0} {1}", student.First, student.Last);

            }

        }

        static public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
               new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
               new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
               new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
               new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
               new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
               new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
               new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
               new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
               new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
               new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
               new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
               new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
            };
            return students;
        }

        static public List<StudentGrades> GetStudentGrades()
        {
            List<StudentGrades> studentsGrades = new List<StudentGrades>()
            {
               new StudentGrades {Math=90, Science=85, StudentID=111},
                new StudentGrades {Math=90, Science=85, StudentID=112}              
            };
            return studentsGrades;
        }
    }
}

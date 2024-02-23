using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDbApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //static type (left) and dynamic type (right)
            DbApp app = new DbApp();
            app.DbAppTest1();
        }
        static void MainTest1()
        {

            // do basic development testing as the DB and
            // the student class are developed.
            Console.WriteLine("Begin Student DB App");

            // We need a way to make students, maybe based on user input?
            Student stu1 = new Student();
            Student stu2 = new Student();
            Student stu3 = new Student("Carlos", "Castaneda", "ccastaneda@uw.edu",  2.5, YearRank.Sophomore);
            Student stu4 = new Student("David", "Davis", "ddavis@uw.edu", 1.5, YearRank.Freshman);



            // first student test
            stu1.FirstName = "Alice";
            stu1.LastName = "Anderson";
            stu1.EmailAddress = "aanderson@uw.edu";
            stu1.GradePtAvg = 4.0;
            stu1.Rank = YearRank.Junior;

            // second student test
            stu2.FirstName = "Bob";
            stu2.LastName = "Bradshaw";
            stu2.EmailAddress = "bbradshawa@uw.edu";
            stu2.GradePtAvg = 3.5;
            stu2.Rank = YearRank.Senior;

            // test output from the objects to the console
            //Console.WriteLine("*** Student Info ********************");
            //Console.WriteLine($"First: {stu1.FirstName}");
           // Console.WriteLine($" Last: {stu1.LastName}");
            //Console.WriteLine($"Email: {stu1.EmailAddress}");
            //Console.WriteLine($"  GPA: {stu1.GradePtAvg}");
            //Console.WriteLine($" Year: {stu1.Rank}");


            //Console.WriteLine("*** Student Info ********************");
            //Console.WriteLine($"First: {stu2.FirstName}");
            //Console.WriteLine($" Last: {stu2.LastName}");
            //Console.WriteLine($"Email: {stu2.EmailAddress}");
            //Console.WriteLine($"  GPA: {stu2.GradePtAvg}");
            //Console.WriteLine($" Year: {stu2.Rank}");

            //Console.WriteLine("Lets see what happens here,:");
            //Console.WriteLine(stu3.ToString());
            //Console.WriteLine(stu4);

            //Console.WriteLine("\n\nEND Student DB App");
        }
    }
}

using System;
using System.Net.Mail;

namespace StudentDbApp
{
    public enum YearRank
    {
        // 0, 1, 2, 3
        Freshman = 0,
        Sophomore = 1,
        Junior = 2,
        Senior = 3
    }
    // The student class will represent a student in the school database/
    // We determine what parameters we wantt to store in that record
    // the student class is an example of encapsulation, the first feature or
    // mechanism of any 00 language. Provides a software component that holds all STATE
    // and BEHAVIOR having to do with an object of that type.

    // Encapsulation in Ch10
    // Inheritance in Ch11
    // Polymorphism in Ch12
    internal class Student
    {

        //attributes we can store
        public string FirstName { get; set; }
        public string LastName { get; set; }


        // intuitively chosen as primary key for record
        public string EmailAddress { get; set; }

        public double GradePtAvg { get; set; }

        public YearRank Rank { get; set; }

        public Student()
        {

        }

        // fully specified ctor
        public Student(string fName, string lName, string email, double gpa, YearRank schoolYear)
        {
            FirstName = fName;
            LastName = lName;
            EmailAddress = email;
            GradePtAvg = gpa;
            Rank = schoolYear;
        }


        // override the TOString method
        // format for output file.
        public string ToStringForOutputFile()
        {
            //declare temp string
            string str = string.Empty;

            // build it up with data from the properties
            str += $"{FirstName}\n";
            str += $"{LastName}\n";
            str += $"{EmailAddress}\n";
            str += $"{GradePtAvg}\n";
            str += $"{Rank}\n";

            // return it, the string
            return str;
        }
        public string ToStringForConsole()
        {
            //declare temp string
            string str = string.Empty;

            // build it up with data from the properties
            str += $"{FirstName}\n";
            str += $"{LastName}\n";
            str += $"{EmailAddress}\n";
            str += $"{GradePtAvg}\n";
            str += $"{Rank}\n";

            // return it, the string
            return str;
        }
    }
}
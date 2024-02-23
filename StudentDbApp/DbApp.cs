using System;
using System.Collections.Generic;
using System.IO;

namespace StudentDbApp
{

    // represents the app itself
    // known in 00 patterns as singleton object
    internal class DbApp
    {
        //what is typical behavior that we need
        //1 store data
        private List<Student> students = new List<Student>();

        //2 we need usual functions in a database (CRUD)
        // add a record to database, create student record
        // find a student record/read student record, print if it's in database
        // edit student record, update student record
        // delete student record if it's in the database

        //utility operations

        public DbApp()
        {

            // test putting data into list
            //DbAppTest1();

            ReadStudentDataFromInputFile();


            RunDatabaseApp();

            

            //test putting data to output file
            WriteDataToOutputFile();
        }

        private void ReadStudentDataFromInputFile()
        {
            //1 - create file stream object. connect it to file on disk
            StreamReader inFile = new StreamReader(StudentInputFile);

            //2 - use the file objec t o actually read input data
            string first = string.Empty;


            //dual purpose statement
            //a - read in astring from file
            //b - set condition for the loop to continue by comparing to null

            while ((first = inFile.ReadLine()) != null)
            {
                string last = inFile.ReadLine();
                string email = inFile.ReadLine();
                double gpa = double.Parse(inFile.ReadLine());
                YearRank year = (YearRank)Enum.Parse(typeof(YearRank), inFile.ReadLine());

                // now make a new student and them to list<>
                Student stu = new Student(first, last, email, gpa, year);
                students.Add(stu);

                Console.WriteLine($"Adding new  student: {stu}");
            }



            //3 release resource by colsing the file.
            inFile.Close();
        }

        private void RunDatabaseApp()
        {
            while (true)
            {
                // display main menu
                DisplayMainMenu();
                //capture user choice, do something with it
                
                char selection = GetUserInputChar();

                switch (selection)
                {
                    case 'A':
                    case 'a':
                        Console.WriteLine("\nA was chosen");
                        AddNewStudentRecord();
                        break;
                    case 'F':
                    case 'f':
                        Console.WriteLine("\nF was chosen");
                        break;
                    case 'M':
                    case 'm':
                        Console.WriteLine("\nM was chosen");
                        break;
                    case 'K':
                    case 'k':
                        Console.WriteLine("\nK was chosen");
                        PrintAllPrimaryKeys();
                        break;
                    case 'P':
                    case 'p':
                        PrintAllRecords();
                        WriteDataToOutputFile();
                        
                        break;
                    case 'S':
                    case 's':
                        WriteDataToOutputFile();
                        Environment.Exit(0);
                        
                        break;
                    case 'E':
                    case 'e':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"ERROR: {selection} is not a valid INPUT. SELECT AGAIN.");
                        break;
                }
            }
        }

        //add new student record
        // precondition: before this is called, determine if the primary key is already used
        // (the desired email address)

        private void AddNewStudentRecord()
        {
            //we need to determine
            //1 what email does new student want
            //2 is the email free

            string email = string.Empty;
            

            Student stu = FindStudentRecord(out email);

            if (stu== null)
            {
                //sunny day scenario for add student - the email is added
                Console.WriteLine("ENTER first name: ");
                string first = Console.ReadLine();
                Console.WriteLine("ENTER last name: ");
                string last = Console.ReadLine();
                Console.WriteLine("ENTER GPA: ");
                double gpa = double.Parse(Console.ReadLine());

                // help user with enum type
                Console.WriteLine("[1] Freshman, [2] Sophomore, [3] Junior, [4] Senior");
                Console.WriteLine("Enter the year in school for this student");
                YearRank year = (YearRank)int.Parse(Console.ReadLine());

                //we now have all info for new student
                Student newStudent = new Student(first, last, email, gpa, year);

                students.Add(newStudent);

                Console.WriteLine($"Adding new student: \n{newStudent} to the database.");
            }
            else
            {
                //email was found and is NOT AVAILABLE
                Console.WriteLine($"{email} RECORD FOUND! Can't add student {email}\n" +
                    $"RECORD already exists.");

            }
        }


        //document this method. don't copy.
        private Student FindStudentRecord(out string email)
        {

            Console.WriteLine("\nENTER the email address to search for: ");
            email = Console.ReadLine();

            foreach (Student stu in students)
            {

                if(email == stu.EmailAddress)
                {

                    Console.WriteLine($"FOUND email address: {stu.EmailAddress}\n");
                    return stu;
                }

            }

            Console.WriteLine($"{email} NOT FOUND.\n");
            return null;

        }

        private void PrintAllPrimaryKeys()
        {
            Console.WriteLine("***** List All Student Emails ******");
            foreach (Student stu in students)
            {
                Console.WriteLine(stu);

            }

            Console.WriteLine("\n***** Done Listing All Student Email");

        }

        private void PrintAllRecords()
        {
            foreach (Student stu in students)
            {
                Console.WriteLine(stu.EmailAddress);
              
            }

            Console.WriteLine("\n***** Done Listing All Student Records");
        }


        // we want to get the user input as a single char from any key press
        // without them having to issue CRLF
        private char GetUserInputChar()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar;
            
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(@"*************************Student Database App****************************
------------------------
------------------
[A]dd a student record (C in CRUD - Create)
[F]ind a student record (R in CRUD - Read)
[M]odify student record (U in CRUD - Update)
[P]rint student record
[K] Print Primary Emails
[D]elete student record
[S] to print out a output file. 
[E]xit without saving changes (D in CRUD - Delete)

User Key Selection: ");


        }

        // without a path, C# goes to default directory
        private const string StudentInputFile = "STUDENT_INPUT_FILE.txt";
        private const string StudentOutputFile = "STUDENT_OUTPUT_FILE.txt";

        public void WriteDataToOutputFile()
        {
            //create output file
            StreamWriter outFile = new StreamWriter(StudentOutputFile);

            //use the file to redirect output to file
            // make sure you close the file.

            Console.WriteLine("-------------------------output data to file using for each loop");
            // iterate through list
            foreach (Student stu in students)
            {
                Console.WriteLine(stu.ToStringForConsole());
                outFile.WriteLine(stu.ToStringForOutputFile());
            }
            outFile.Close();
            Console.WriteLine("Done writing to File");

        }
 
        public void DbAppTest1()
        {
            // do basic development testing as the DB and
            // the student class are developed.
            Console.WriteLine("Begin Student DB App");

            // We need a way to make students, maybe based on user input?
            Student stu1 = new Student();
            Student stu2 = new Student();
            Student stu3 = new Student("Carlos", "Castaneda", "ccastaneda@uw.edu", 2.5, YearRank.Sophomore);
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


            // take all 4 students and their data to the list
            students.Add(stu1);
            students.Add(stu2);
            students.Add(stu3);
            students.Add(stu4);


            

            Console.WriteLine("Output data using regular for loop");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }


            Console.WriteLine("\nEND STUDENT APP");
        }
    }
}
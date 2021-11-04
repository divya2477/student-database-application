using StudentDatabaseManagement.BaseClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentDatabaseManagement.StudentOperations
{
    class Operations
    {
        public static List<Student> studentsList = new List<Student>();
        public static string userID = "";
        public static Boolean isLoggedIn = false;

        public void checkForValidLogin()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Student Portal!");
            isLoggedIn = false;
            studentsList = fetchStudents();
            Console.WriteLine("Please enter your Student ID");
            string studentID = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            foreach (Student student in studentsList)
            {
                if (studentID.Equals(student.Id))
                {
                    if (password.Equals(student.Password))
                    {
                        userID = student.Id;
                        isLoggedIn = true;
                    }
                }
            }
            if (isLoggedIn)
            {
                for (; false == chooseOperation();)
                {
                    chooseOperation();
                }
            }
            else
            {
                for (; false == loginOperation();)
                {
                    loginOperation();
                }

            }
        }

        public Boolean loginOperation()
        {
            Boolean validFlag = true;
            Console.WriteLine("Invalid Login!");
            Console.WriteLine("Press 1 to Login!");
            Console.WriteLine("Press 2 to Register!");
            Console.WriteLine("Press 3 to Exit!");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    checkForValidLogin();
                    break;
                case "2":
                    register();
                    break;
                case "3":
                    closeApplication();
                    break;
                default:
                    validFlag = false;
                    Console.WriteLine("Invalid selection!");
                    break;
            }
            return validFlag;
        }

        public Boolean chooseOperation()
        {
            Boolean validFlag = true;
            Console.WriteLine("Press 1 to View Profile!");
            Console.WriteLine("Press 2 to View TimeTable!");
            Console.WriteLine("Press 3 to Logout!");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    viewProfile(userID);
                    break;
                case "2":
                    viewTimeTable();
                    break;
                case "3":
                    closeApplication();
                    break;
                default:
                    validFlag = false;
                    Console.WriteLine("Invalid selection!");
                    break;
            }
            return validFlag;
        }

        public void viewProfile(string studentID)
        {
            Console.Clear();
            foreach (Student stu in studentsList)
            {
                if (stu.Id.Equals(studentID))
                {
                    Console.WriteLine(stu.Name + " profile : ");
                    Console.WriteLine("ID : " + stu.Id);
                    Console.WriteLine("Name : " + stu.Name);
                    Console.WriteLine("Password : " + stu.Password);
                    Console.WriteLine("Intake : " + stu.Intake);
                    Console.WriteLine("Course : " + stu.Course);
                    Console.WriteLine("Email : " + stu.Email);
                    Console.WriteLine("Mobile Number : " + stu.MobileNumber);
                    Console.WriteLine("Address : " + stu.Address);
                }
            }
            for (; false == backFunction();)
            {
                backFunction();
            }
        }

        public Boolean backFunction()
        {
            Boolean backFlag = false;
            Console.WriteLine("Press 1 to go back to the previous menu!");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    backFlag = true;
                    chooseOperation();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    backFlag = false;
                    break;
            }
            return backFlag;
        }

        public void viewTimeTable()
        {
            Console.WriteLine("Weekly Timetable");
            Console.WriteLine("Monday : 5-8 PM : BDAT-1000 Data Manipulation");
            Console.WriteLine("Tuesday : 1-4 PM : BDAT-1003 Business Process");
            Console.WriteLine("Tuesday : 5-8 PM : BDAT-1005 Math For Data Analytics");
            Console.WriteLine("Wednesday : 5-8 PM : BDAT-1001 Information Encoding");
            Console.WriteLine("Thursday : 1-4 PM : BDAT-1002 Data Systems Architecture");
            Console.WriteLine("Thursday : 5-8 PM : BDAT-1004 Data Programming");
            for (; false == backFunction();)
            {
                backFunction();
            }
        }

        public List<Student> fetchStudents()
        {
            return CSVReadWrite.CSVReader();
        }

        public void register()
        {
            StringBuilder csv = new StringBuilder();
            Console.Clear();
            Console.WriteLine("Please enter your details to register!");
            Student newStudent = new Student();
            Console.WriteLine("Enter your Student ID");
            newStudent.Id = Console.ReadLine();
            csv.Append(newStudent.Id).Append(",");
            Console.WriteLine("Enter your Name");
            newStudent.Name = Console.ReadLine();
            csv.Append(newStudent.Name).Append(",");
            Console.WriteLine("Enter your Password");
            newStudent.Password = Console.ReadLine();
            csv.Append(newStudent.Password).Append(",");
            Console.WriteLine("Enter your Intake");
            newStudent.Intake = Console.ReadLine();
            csv.Append(newStudent.Intake).Append(",");
            Console.WriteLine("Enter your Course");
            newStudent.Course = Console.ReadLine();
            csv.Append(newStudent.Course).Append(",");
            Console.WriteLine("Enter your Email");
            newStudent.Email = Console.ReadLine();
            csv.Append(newStudent.Email).Append(",");
            Console.WriteLine("Enter your Mobile Number");
            newStudent.MobileNumber = Console.ReadLine();
            csv.Append(newStudent.MobileNumber).Append(",");
            Console.WriteLine("Enter your Address");
            newStudent.Address = Console.ReadLine();
            csv.Append(newStudent.Address);
            CSVReadWrite.CSVWriter(csv.ToString());
            Console.Clear();
            Console.WriteLine("Profile created sucessfully!");
            Console.WriteLine("Please Login!");
            checkForValidLogin();
        }

        public void closeApplication()
        {
            isLoggedIn = false;
            Environment.Exit(0);
        }

        public void logout()
        {
            isLoggedIn = false;
            Console.WriteLine("You have been logged out successfully!");
        }
    }
}


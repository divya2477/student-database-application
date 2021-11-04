using System;
using System.Collections.Generic;
using System.Text;

namespace StudentDatabaseManagement.BaseClass
{
    class Student
    {
        private string id;
        private string name;
        private string password;
        private string course;
        private string intake;
        private string email;
        private string mobileNumber;
        private string address;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Course { get => course; set => course = value; }
        public string Intake { get => intake; set => intake = value; }
        public string Email { get => email; set => email = value; }
        public string MobileNumber { get => mobileNumber; set => mobileNumber = value; }
        public string Address { get => address; set => address = value; }
    }
}

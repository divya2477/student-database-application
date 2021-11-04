using StudentDatabaseManagement.StudentOperations;
using System;

namespace StudentDatabaseManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations op = new Operations();
            op.checkForValidLogin();
        }
    }
}

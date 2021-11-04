using StudentDatabaseManagement.BaseClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace StudentDatabaseManagement.StudentOperations
{
    class CSVReadWrite
    {
        public static string filePath = @"E:\Georgian\DataFiles\student.csv";

        public static List<Student> CSVReader()
        {
            List<Student> studentList = new List<Student>();
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {

                    while (!reader.EndOfStream)
                    {
                        Student stu = new Student();
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        stu.Id = values[0];
                        stu.Name = values[1];
                        stu.Password = values[2];
                        stu.Intake = values[3];
                        stu.Course = values[4];
                        stu.Email = values[5];
                        stu.MobileNumber = values[6];
                        stu.Address = values[7];
                        studentList.Add(stu);
                    }
                }

            }
            return studentList;
        }

        public static void CSVWriter(string str)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, str);
            }
            else
            {
                File.AppendAllText(filePath, "\n");
                File.AppendAllText(filePath, str);
            }
        }
    }
}

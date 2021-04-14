using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group
            {
                Number = "101",
                Title = "Факультет энергетического строительства",
            };

            Group group2 = new Group
            {
                Number = "201",
                Title = "Факультет транспортных коммуникаций",
            };

            Group group3 = new Group
            {
                Number = "301",
                Title = "Факультет информационных технологий и робототехники",
            };

            Student student1 = new Student
            {
                ID = "10111",
                Name = "Олег",
                SurName = "Морозов",
                Marks = new List<int> { 4, 5, 4, 5 },
                Group = group1
            };

            Student student2 = new Student
            {
                ID = "10112",
                Name = "Яна",
                SurName = "Пашкевич",
                Marks = new List<int> { 4, 5, 5, 5 },
                Group = group1
            };

            Student student3 = new Student
            {
                ID = "20211",
                Name = "Павел",
                SurName = "Климов",
                Marks = new List<int> { 4, 4, 3, 3 },
                Group = group2
            };

            Student student4 = new Student
            {
                ID = "20212",
                Name = "Мария",
                SurName = "Иванова",
                Marks = new List<int> { 5, 5, 5, 4 },
                Group = group2
            };

            Student student5 = new Student
            {
                ID = "30311",
                Name = "Кирилл",
                SurName = "Петров",
                Marks = new List<int> { 5, 5, 5, 5 },
                Group = group3
            };

            Student student6 = new Student
            {
                ID = "30312",
                Name = "Анжела",
                SurName = "Мухина",
                Marks = new List<int> { 5, 4, 4, 4 },
                Group = group3
            };

            List<Group> groups = new List<Group> { group1, group2, group3 };

            List<Student> students = new List<Student> { student1, student2, student3, student4, student5, student6 };

            while (true)
            {
                Console.WriteLine("Введите команду. \n 1 - Список студентов," +
                    " \n 2 - Добавить студента,\n 3 - Редактировать студента, " +
                    "\n 4 - Удалить студента, \n 5 - Список групп, \n 6 - Добавить группу, \n " +
                    "7 - Редактировать групп, \n 8 - Удалить группу \n Q - quit");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Student.PrintStudents(students);
                        break;
                    case "2":
                        Console.WriteLine("В какую группу добавить студента?");

                        for (int i = 0; i < groups.Count; i++)
                        {
                            Console.Write($"№{i} ");
                            Console.WriteLine(groups[i].Title);
                        }
                        Console.WriteLine("Введите №:");
                        var inputGroup = int.Parse(Console.ReadLine());
                        Student newstudent = new Student();
                        newstudent = Student.AddStudent(groups[inputGroup]);
                        students.Add(newstudent);
                        break;
                    case "3":
                        Student.EditStudent(students, groups);
                        break;
                    case "4":
                        Student.Removestudent(students);
                        break;
                    case "5":
                        Group.PrintGroups(groups);
                        break;
                    case "6":
                        var newgroup = Group.AddGroup(groups);
                        groups.Add(newgroup);
                        break;
                    case "7":
                        Group.EditGroup(groups);
                        break;
                    case "8":
                        Group.RemoveGroup(groups);
                        break;
                    case "Q":
                    case "q":
                        return;
                }

            }

        }
       
        

        

        

    }
}

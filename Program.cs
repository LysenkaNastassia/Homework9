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
                        PrintStudents(students);
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
                        newstudent = AddStudent(groups[inputGroup]);
                        students.Add(newstudent);
                        break;
                    case "3":
                        EditStudent(students, groups);
                        break;
                    case "4":
                        Removestudent(students);
                        break;
                    case "5":
                        PrintGroups(groups);
                        break;
                    case "6":
                        var newgroup = AddGroup(groups);
                        groups.Add(newgroup);
                        break;
                    case "7":
                        EditGroup(groups);
                        break;
                    case "8":
                        RemoveGroup(groups);
                        break;
                    case "Q":
                    case "q":
                        return;
                }

            }

        }
        private static void PrintStudents(List<Student> students)
        {
            Console.WriteLine("Список студентов:");
            foreach (var student in students)
            {
                Console.Write($"{student.ID}. {student.Name} {student.SurName}");
                Console.Write(" Оценки: ");
                foreach (var mark in student.Marks)
                {
                    Console.Write(mark + " ");
                }
                Console.Write(student.Group.Title);
                Console.WriteLine();
            }
        }


        private static Student AddStudent(Group group)
        {
            Student newStudent = new Student();
            Console.WriteLine("Введите ID номер студента по образцу: ХХХХХ");
            newStudent.ID = Console.ReadLine();
            Console.WriteLine("Введите имя студента:");
            newStudent.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию студента:");
            newStudent.SurName = Console.ReadLine();
            Console.WriteLine("Введите оценки студента:");
            newStudent.Marks = new List<int>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "")
                    break;
                else
                {
                    var mark = int.Parse(command.Trim());
                    newStudent.Marks.Add(mark);
                }
            }
            newStudent.Group = group;
            return newStudent;
        }

        private static List<Student> Removestudent(List<Student> students)
        {
            Console.WriteLine("Введите ID студента:");
            for (int i = 0; i < students.Count; i++)
            {
                var removeStudent = Console.ReadLine();
                if (removeStudent == students[i].ID)
                {
                    students.RemoveAt(i);
                    Console.WriteLine("Студент удален.");
                    break;
                }
                else
                {
                    Console.WriteLine("Студент не найден.");
                    break;
                }
            }
            return students;
        }

        private static void EditStudent(List<Student> students, List<Group> groups)
        {
            Console.WriteLine("Введите ID студента:");
            var id = Console.ReadLine();
            var studentToUpdate = students.FirstOrDefault(s => s.ID == id);
            if (studentToUpdate == null)
            {
                Console.WriteLine("Студент не найден.");
                return;
            }
            Console.WriteLine("Введите новые данные студента");
            Console.WriteLine("Введите имя студента: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию студента: ");
            var surName = Console.ReadLine();

            studentToUpdate.Name =
                string.IsNullOrWhiteSpace(firstName)
                ? studentToUpdate.Name
                : firstName;

            studentToUpdate.SurName =
               string.IsNullOrWhiteSpace(surName)
              ? studentToUpdate.SurName
              : surName;

            Console.WriteLine("Введите оценки студента: ");

            List<int> newMarks = new List<int>();

            while (true)
            {
                var mark = Console.ReadLine();
                if (mark == "")
                    break;
                else
                {
                    var newmark = int.Parse(mark);
                    newMarks.Add(newmark);
                }

            }

            studentToUpdate.Marks = newMarks;

            Console.WriteLine("Введите номер группы: ");
            var groupNumber = Console.ReadLine();
            for (int i = 0; i < groups.Count; i++)
            {
                if (groupNumber != "")
                {
                    var group = groups.FirstOrDefault(g => g.Number == groupNumber);
                    if (group == null)
                    {
                        Console.WriteLine("Группа не найдена.");
                        return;
                    }
                    studentToUpdate.Group = group;
                    break;
                }

            }
            
        }

        private static void PrintGroups(List<Group> groups)
        {
            Console.WriteLine("Список групп:");
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Number} {group.Title}");
            }

        }

        private static Group AddGroup(List<Group> groups)
        {
            Console.WriteLine("Введите номер группы:");
            var number = Console.ReadLine();
            Console.WriteLine("Введите название группы:");
            var title = Console.ReadLine();
            Group group = new Group { Number = number, Title = title };
            return group;
        }

        private static List<Group> RemoveGroup(List<Group> groups)
        {
            Console.WriteLine("Введите номер группы:");
            for (int i = 0; i < groups.Count; i++)
            {
                var removeGroup = Console.ReadLine();
                if (removeGroup == groups[i].Number)
                {
                    groups.RemoveAt(i);
                    Console.WriteLine("Группа удалена.");
                    break;
                }
                else
                {
                    Console.WriteLine("Группа не найдена.");
                    break;
                }
            }
            return groups;
        }

        private static void EditGroup(List<Group> groups)
        {
            Console.WriteLine("Введите номер группы:");
            var numberGroup = Console.ReadLine();
            var groupToUpdate = groups.FirstOrDefault(g => g.Number == numberGroup);
            if (groupToUpdate == null)
            {
                Console.WriteLine("Группа не найдена.");
                return;
            }
            Console.WriteLine("Введите новые данные группы");
            Console.WriteLine("Введите название группы: ");
            var newTitle = Console.ReadLine();
            
            groupToUpdate.Title =
                string.IsNullOrWhiteSpace(newTitle)
                ? groupToUpdate.Title
                : newTitle;
        }

    }
}

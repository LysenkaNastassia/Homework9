using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework9
{
   
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<int> Marks { get; set; }
        public Group Group { get; set; }

        public static Student AddStudent(Group group)
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

        public static void PrintStudents(List<Student> students)
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

        public static void EditStudent(List<Student> students, List<Group> groups)
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
        public static List<Student> Removestudent(List<Student> students)
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

    }

}


    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework9
{
    public class Group
    {
        public string Number { get; set; }
        public string Title { get; set; }

        public static void PrintGroups(List<Group> groups)
        {
            Console.WriteLine("Список групп:");
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Number} {group.Title}");
            }

        }

        public static Group AddGroup(List<Group> groups)
        {
            Console.WriteLine("Введите номер группы:");
            var number = Console.ReadLine();
            Console.WriteLine("Введите название группы:");
            var title = Console.ReadLine();
            Group group = new Group { Number = number, Title = title };
            return group;
        }

        public static List<Group> RemoveGroup(List<Group> groups)
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

        public static void EditGroup(List<Group> groups)
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

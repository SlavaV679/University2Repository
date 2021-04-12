using System;
using System.Collections.Generic;
using System.Linq;
using University.Models;

namespace University.Logic
{
    public class TeacherLogic
    {
        public List<Teacher> GenerateTeachers()
        {
            return new List<Teacher>
            {
                new Teacher(1, Teacher.Genders.Female, "Alena", "Petrovna",
                    "Mathematics", 45, 1),
                new Teacher(2, Teacher.Genders.Female, "Galina", "Ivanovna",
                    "Physics", 49, 2),
                new Teacher(3, Teacher.Genders.Male, "Azat", "Renatovich",
                    "Chemistry", 51, 1),
                new Teacher(4, Teacher.Genders.Male, "Alexandr", "Petrovich",
                    "History and Sociology", 53, 3),
                new Teacher(5, Teacher.Genders.Male, "Nikolai", "Vasilievich",
                    "Computer science", 40, 1),
                new Teacher(6, Teacher.Genders.Female, "Galina", "Vasilievna",
                    "Geology", 35, 4),
                new Teacher(7, Teacher.Genders.Female, "Diana", "Vladimirovna",
                    "Biology", 37, 5),
            };
        }

        public IEnumerable<string> GetAllTeachers()
        {
            var teachers = GenerateTeachers();
            var univerLogic = new UniverLogic();
            var univers = univerLogic.GenerateUnivers();
            var univerTeachers =
                from teacher in teachers
                join univer in univers
                    on teacher.UniverId equals univer.Id
                select new UniverTeacher(teacher, univer);
            List<string> teachersList = new List<string>();
            foreach (var ut in univerTeachers)
            {
                teachersList.Add
                    (
                        $" {ut.Teacher.GendersDisplayNames[ut.Teacher.Gender]} " +
                        $"{ut.Teacher.Name} " +
                        $"{ut.Teacher.Patronymic} teaches " +
                        $"{ut.Teacher.Lesson} at " +
                        $"{ut.Univer.Name}. "
                    );
            }
            return teachersList;
        }

        public string GetOneTeacher(int teacherId)
        {
            var teachers = GenerateTeachers();
            var univerLogic = new UniverLogic();
            var univers = univerLogic.GenerateUnivers();
            var univerTeachers =
                from teacher in teachers
                join univer in univers
                    on teacher.UniverId equals univer.Id
                select new UniverTeacher(teacher, univer);

            var ut =
                univerTeachers.SingleOrDefault(uT => uT.Teacher.Id == teacherId);
            if (ut == null)
            {
                throw new Exception($" Teacher with Id = {teacherId} not found. ");
            }
            return $" {ut.Teacher.GendersDisplayNames[ut.Teacher.Gender]} " +
                   $"{ut.Teacher.Name} " +
                   $"{ut.Teacher.Patronymic} teaches " +
                   $"{ut.Teacher.Lesson} at " +
                   $"{ut.Univer.Name}. ";
        }
    }
}
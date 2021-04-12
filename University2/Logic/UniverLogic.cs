using System;
using System.Collections.Generic;
using System.Linq;
using University.Models;

namespace University.Logic
{
    public class UniverLogic
    {
        public List<Univer> GenerateUnivers()
        {
            return new List<Univer>
            {
                new Univer(1, "KGU", "Kazan State University"),
                new Univer(2, "KFTI", "Kazan Institute of Physics and Technology"),
                new Univer(3, "KGASU", "Kazan State University of Architecture and Civil Engineering"),
                new Univer(4, "KGEU", "Kazan State Power Engineering University"),
                new Univer(5, "KGMA", "Kazan State Medical University"),
                new Univer(7, "KAI", "Kazan Aviation Institute"),

            };
        }

        public IEnumerable<string> GetAllUnivers()
        {
            var univers = GenerateUnivers();
            var teacherLogic = new TeacherLogic();
            var teachers = teacherLogic.GenerateTeachers();
            var studentLogic = new StudentLogic();
            var students = studentLogic.GenerateStudents();

            List<string> univTeachSudList = new List<string>();
            foreach (var univer in univers)
            {
                int teachersCount = teachers.Count(t => t.UniverId == univer.Id);
                int studentsCount = students.Count(s => s.UniverId == univer.Id);
                univTeachSudList.Add($" The {univer.FullName} " +
                                     $"({univer.Name}) has " +
                                     $"{teachersCount} teachers and " +
                                     $"{studentsCount} students. ");
            }
            return univTeachSudList;
        }

        public IEnumerable<string> GetAllInfo()
        {
            var univers = GenerateUnivers();
            var teacherLogic = new TeacherLogic();
            var teachers = teacherLogic.GenerateTeachers();
            var studentLogic = new StudentLogic();
            var students = studentLogic.GenerateStudents();

            var univerTeachersStudents =
                from univer in univers
                join teacher in teachers on univer.Id equals teacher.UniverId
                join student in students on univer.Id equals student.UniverId
                select new UniverStudentTeacher(univer, teacher, student);

            var groups = univerTeachersStudents
                .GroupBy(x => x.Univer, elem => new { elem.Teacher, elem.Student })
                .ToList();

            List<string> univerTeachStudList = new List<string>();

            foreach (var gr in groups)
            {
                var teachersGr = gr
                    .Where(t => t != null && t.Teacher != null)
                    .Select(t => t.Teacher)
                    .Distinct()
                    .ToList();

                var teacherStr = GetTeacherDescription(teachersGr);
                 
                var studentsGr = gr
                    .Where(s => s?.Student != null)
                    .Select(s => s.Student)
                    .Distinct()
                    .ToList();

                var sNameList = GetStudentDescription(studentsGr);

                univerTeachStudList
                    .Add($" The {gr.Key.FullName} has " +
                         $" {teacherStr} and " +
                         $" {sNameList}. ");
            }

            return univerTeachStudList;
        }

        private string GetTeacherDescription(List<Teacher> teachers)
        {
            string result = teachers
                .Aggregate("teachers: ", 
                (current, teacher) => current + ($"{teacher.Name} {teacher.Patronymic}" + ", "),
                x => x.TrimEnd(',', ' '));

            return result;
        }

        private string GetStudentDescription(List<Student> students)
        {
            string result = students
                .Aggregate("students: ",
                (current, student) => current + ($"{student.Name} " + ", "),
                x => x.TrimEnd(',', ' '));

            return result;
        }

        public string GetInfo(int id)
        {
            var univers = GenerateUnivers();
            var teacherLogic = new TeacherLogic();
            var teachers = teacherLogic.GenerateTeachers();
            var studentLogic = new StudentLogic();
            var students = studentLogic.GenerateStudents();

            var univer = univers
                .SingleOrDefault(u => u.Id == id);
            if (univer == null)
            {
                throw new Exception(" University with Id = " +
                                    $"{id} was not found. ");
            }
            int studentsCount = students
                .Count(s => s.UniverId == id);
            int teachersCount = teachers
                .Count(t => t.UniverId == id);

            return $" The {univer.FullName} ({univer.Name}) " +
                   $"has {studentsCount} students and " +
                   $"{teachersCount} teachers. ";
        }

        public string GetInfo(string univerName)
        {
            var univers = GenerateUnivers();
            var teacherLogic = new TeacherLogic();
            var teachers = teacherLogic.GenerateTeachers();
            var studentLogic = new StudentLogic();
            var students = studentLogic.GenerateStudents();

            var univer = univers
                .SingleOrDefault(u => u.Name == univerName);
            if (univer == null)
            {
                throw new Exception(" University with univerName = " +
                                    $"{univerName} was not found. ");
            }
            int studentsCount = students
                .Count(s => s.UniverId == univer.Id);
            int teachersCount = teachers
                .Count(t => t.UniverId == univer.Id);

            return $" The {univer.FullName} ({univer.Name}) " +
                   $"has {studentsCount} students and " +
                   $"{teachersCount} teachers. ";
        }

        public List<string> GetUniverStudents(int univerId)
        {
            var studentLogic = new StudentLogic();
            var studentList = studentLogic.GenerateStudents();
            if (studentList.Any(s => s.UniverId == univerId) == false)
            {
                throw new Exception(" Students studying at the university with " +
                                    $"Id = {univerId} was not found. ");
            }
            return studentList
                .Where(student => student.UniverId == univerId)
                .Select(student => student.Name)
                .ToList();
        }

        public List<string> GetUniverStudents(string univerName)
        {
            UniverLogic univerLogic = new UniverLogic();
            List<Univer> univerList = univerLogic.GenerateUnivers();
            var univerListSortedName = univerList
                .Where(univer => univer.Name == univerName)
                .ToList();
            if (!univerListSortedName.Any()) 
            {
                throw new Exception($" University with name {univerName} " +
                                    "was not found in the database 'Univer'. ");
            }
            var studentLogic = new StudentLogic();
            var studentList = studentLogic.GenerateStudents();
            var univerStudents = from student in studentList
                join univer in univerListSortedName
                    on student.UniverId equals univer.Id
                select new UniverStudent(student, univer);

            return univerStudents
                .Select(su => $" {su.Student.Name} studies at {su.Univer.Name} ")
                .ToList();
        }
    }
}
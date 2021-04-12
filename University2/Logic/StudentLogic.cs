using System;
using System.Collections.Generic;
using System.Linq;
using University.Models;

namespace University.Logic
{
    public class StudentLogic
    {
        public List<Student> GenerateStudents()
        {
            return new List<Student>
            {
                new Student(1, "Vasia", 17, 1),
                new Student(2, "Kolia", 22, 2),
                new Student(3, "Sasha", 20, 3),
                new Student(4, "Nastia", 19, 3),
                new Student(5, "Slava", 18, 1),
                new Student(6, "Dima", 22, 2),
                new Student(7, "Denis", 24, 4),
                new Student(8, "Roman", 24, 1),
                new Student(9, "Petia", 20, 4),
                new Student(10, "Nina", 19, 2),
                new Student(11, "Igor", 22, 1),
                new Student(12, "Roman", 18, 5),
                new Student(13, "Petr", 17, 1),
                new Student(14, "Nina", 20, 5),
                new Student(15, "Olga", 19, 1),
                new Student(16, "Alesha", 17, 6),
            };
        }

        public List<Car> GenerateCars()
        {
            return new List<Car>
            {
                new Car(1, "BMW", 8.560),
                new Car(3, "Lada Vesta", 3.330),
                new Car(7, "W Polo", 3.330),
                new Car(8, "Ford", 8.560),
                new Car(9, "Nissan", 7.245),
            };
        }

        internal List<string> GetAllStudents()
        {
            var studentLogic = new StudentLogic();
            var students = studentLogic.GenerateStudents();
            var univerLogic = new UniverLogic();
            var univers = univerLogic.GenerateUnivers();
            var univerStudent =
                from student in students
                join univer in univers
                    on student.UniverId equals univer.Id
                select new UniverStudent(student, univer);

            List<string> studentsList = new List<string>();
            foreach (var uStudent in univerStudent)
            {
                studentsList.Add
                    (
                        $" A student {uStudent.Student.Name} aged {uStudent.Student.Age} " +
                        $"years studying at {uStudent.Univer.Name}. "
                    );
            }
            return studentsList;
        }

        public string GetName(Student student)
        {
            var univerLogic = new UniverLogic();
            var univers = univerLogic.GenerateUnivers();
            var univer = univers
                .SingleOrDefault(u => u.Id == student.UniverId);
            if (univer == null)
            {
                throw new Exception($" Univer with Id = {student.UniverId} " +
                                    $"in which student {student.Name} " +
                                    $"(with Id = {student.Id}) is studying " +
                                    "is not found in DataBase 'Univers'! ");
            }
            return $" A student {student.Name} aged {student.Age} years " +
                   $"studying at {univer.Name}. ";
        }

        public List<StudentCar> GetStudentsCars()
        {
            var students = GenerateStudents();
            var cars = GenerateCars();
            var studentsCars = from student in students
                join car in cars on student.Id equals car.StudentId
                select new StudentCar(student, car);
            return studentsCars.ToList();
        }

        public List<StudentCar> GetMostExpensiveStudentCar()
        {
            var students = GenerateStudents();
            var cars = GenerateCars();
            var maxPrice = cars.Max(carr => carr.Price);
            var mostExpensiveCars = cars
                .Where(car => car.Price == maxPrice);
            var studentsWithExpensivCar = from student in students
                join expensiveCar in mostExpensiveCars
                    on student.Id equals expensiveCar.StudentId
                select new StudentCar(student, expensiveCar);
            return studentsWithExpensivCar
                .ToList();
        }

        public List<string> GetMostInexpensiveStudentCar()
        {
            var students = GenerateStudents();
            var cars = GenerateCars();
            var mostInexpensiveCars = cars
                .Where(car => car.Price == cars.Min(carr => carr.Price));
            var studentsWithInexpensivCar = from student in students
                join inexpensiveCar in mostInexpensiveCars
                    on student.Id equals inexpensiveCar.StudentId
                select new StudentCar(student, inexpensiveCar);
            List<string> str = new List<string>();
            foreach (var studentWithInexpensiveCar in studentsWithInexpensivCar)
            {
                str.Add(studentWithInexpensiveCar.Student.Name +
                        " have a most inexpensive car " +
                        studentWithInexpensiveCar.Car.Name +
                        " which cost " +
                        studentWithInexpensiveCar.Car.Price);
            }
            return str;
        }

        public Student GetStudent(int studentId)
        {
            StudentLogic studentLogic = new StudentLogic();
            List<Student> students = studentLogic.GenerateStudents();
            var student = students.SingleOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception($" Student with Id = {studentId} not found! ");
            }
            return student;
        }

        public List<string> GetOldestStudent()
        {
            var students = GenerateStudents();
            return students
                .Where(stud => stud.Age == students.Max(st => st.Age))
                .Select(stud => $" {stud.Name} is oldest student" +
                                $" aged {stud.Age}. ")
                .ToList();
        }

        public List<string> GetYoungestStudent()
        {
            var students = GenerateStudents();
            return students
                .Where(stud => stud.Age == students.Min(st => st.Age))
                .Select(stud => $" {stud.Name} is youngest student " +
                                $"aged {stud.Age}. ")
                .ToList();
        }

        #region
        //private int itemOfFactorial = 1;
        //private int TempResultFactorial = 1;
        //private int ResultFactorial = 1;
        //public int SummingByStudent(int a, int b, bool isClever)
        //{
        //    if (isClever) return a + b;
        //    return a + b + 100;
        //}

        //public string CapitalOfCountry(string country)
        //{
        //    if (country == "Russia")
        //        return "Moscow";
        //    if (country == "USA")
        //        return "Washington";
        //    if (country == "England")
        //        return "London";
        //    return "Unknown request";
        //}

        //public string AboutStudent(bool aboutYuoself, Student student)
        //{
        //    if (aboutYuoself)
        //    {
        //        return "My name is" + student.NameStudent + ". /n"
        //               + "I'm" + student.AgeStudent + "years old. /n";
        //    }
        //    return "Not Request";
        //}

        //public int GetFactorial(int valueForFactorial)
        //{
        //    TempResultFactorial *= itemOfFactorial;
        //    itemOfFactorial++;
        //    if (itemOfFactorial < valueForFactorial)
        //        GetFactorial(valueForFactorial);
        //    ResultFactorial = TempResultFactorial;
        //    itemOfFactorial = 1;
        //    TempResultFactorial = 1;
        //    return ResultFactorial;
        //    {
        //        //TempResultFactorial = 1;
        //        //for (int i = 1; i < valueForFactorial + 1; i++)
        //        //{
        //        //    i *= i;
        //        //    TempResultFactorial *= i;
        //        //}
        //        //return TempResultFactorial;
        //    }
        //}
        #endregion
    }
}
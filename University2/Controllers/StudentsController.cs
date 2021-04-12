using System;
using System.Collections.Generic;
using University.Logic;
using University.Models;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    /// <summary>
    /// Студенты
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// Получение списка имен студентов
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/students/all")]
        public IEnumerable<string> GetAllStudents()
        {
            StudentLogic studentLogic = new StudentLogic();
            List<string> students = studentLogic.GetAllStudents();
            return students;
        }

        /// <summary>
        /// Получение списка машин у студентов
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/students/cars")]
        public IEnumerable<string> GetStudentsCars()
        {
            StudentLogic studentLogic = new StudentLogic();
            List<StudentCar> studentCar = studentLogic.GetStudentsCars();
            List<string> str = new List<string>();
            foreach (var studentCarEvery in studentCar)
            {
                str.Add(studentCarEvery.Student.Name + " have "
                        + studentCarEvery.Car.Name);
            }
            return str;
        }

        /// <summary>
        /// Получение списка самых дорогих машин у студентов со значением стоимости
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/students/expensivecar")]
        public IEnumerable<string> GetMostExpensiveStudentsCars()
        {
            StudentLogic studentLogic = new StudentLogic();
            List<StudentCar> mostExpensiveStudentCar =
                studentLogic.GetMostExpensiveStudentCar();
            List<string> str = new List<string>();
            foreach (var expensiveStudentCarEvery in mostExpensiveStudentCar)
            {
                str.Add(expensiveStudentCarEvery.Student.Name + " have "
                        + expensiveStudentCarEvery.Car.Name + " which cost "
                        + expensiveStudentCarEvery.Car.Price);
            }
            return str;
        }

        /// <summary>
        /// Получение списка самых НЕ дорогих машин у студентов
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/students/inexpensivecar")]
        public IEnumerable<string> GetMostInexpensiveStudentsCars()
        {
            StudentLogic studentLogic = new StudentLogic();
            return studentLogic.GetMostInexpensiveStudentCar();
        }

        /// <summary>
        /// Получение списка самых старших студентов
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/students/oldest")]
        public IEnumerable<string> GetOldestStudent()
        {
            StudentLogic studentLogic = new StudentLogic();
            return studentLogic.GetOldestStudent();
        }

        /// <summary>
        /// Получение списка самых младших студентов
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/students/youngest")]
        public IEnumerable<string> GetYoungestStudent()
        {
            StudentLogic studentLogic = new StudentLogic();
            return studentLogic.GetYoungestStudent();
        }

        /// <summary>
        /// Получение имени студента с Id = id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/students/name")]
        public string GetStudentName(int id)
        {
            try
            {
                StudentLogic studentLogic = new StudentLogic();
                var student = studentLogic.GetStudent(id);
                return studentLogic.GetName(student);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}

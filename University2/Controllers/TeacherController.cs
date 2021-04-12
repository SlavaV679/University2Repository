using System;
using System.Collections.Generic;
using University.Logic;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        /// <summary>
        /// Получение списка сгенерированных учителей (Имя Отчество)
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/teacher/all")]
        public IEnumerable<string> GetAllTeachers()
        {
            TeacherLogic teacherLogic = new TeacherLogic();
            return teacherLogic.GetAllTeachers();
        }

        /// <summary>
        /// Полуение Имя Отчества учителя Id = teacherId
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/teacher/one")]
        public string GetOneTeacher(int teacherId)
        {
            try
            {
                TeacherLogic teacherLogic = new TeacherLogic();
                return teacherLogic.GetOneTeacher(teacherId);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}

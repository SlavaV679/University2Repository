using System;
using System.Collections.Generic;
using System.Linq;
using University.Logic;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniverController : ControllerBase
    {
        /// <summary>
        /// Получение списка всех универов (названия, количества студентов и учителей)
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/univer/all")]
        public IEnumerable<string> GetAllUnivers()
        {
            var univerLogic = new UniverLogic();
            return univerLogic.GetAllUnivers();
        }

        /// <summary>
        /// Получение списка универов, в котором для каждого универа перечислены по именам все студенты и учителя.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/univer/allinfo")]
        public IEnumerable<string> GetAllInfo()
        {
            var univerLogic = new UniverLogic();
            return univerLogic.GetAllInfo();
        }
 
        // http://localhost:3842/api/univer/info?id=2
        /// <summary>
        /// Получение названия, количества студентов и учителей в универе с Id = id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/univer/infobyid")]
        public string GetInfo(int id)
        {
            try
            {
                UniverLogic univerLogic = new UniverLogic();
                return univerLogic.GetInfo(id);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Получение названия, количества студентов и учителей в универе с Name = univerName
        /// </summary>
        /// <param name="univerName"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/univer/infobyname")]
        public string GetInfo(string univerName)
        {
            try
            {
                UniverLogic univerLogic = new UniverLogic();
                return univerLogic.GetInfo(univerName);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Получение списка студентов, которые учатся в университете с Id = univerId
        /// </summary>
        /// <param name="univerId"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/univer/studentsbyid")]
        public Tuple<string, List<string>> GetUniverStudents(int univerId)
        {
            try
            {
                UniverLogic univerLogic = new UniverLogic();
                var univers = univerLogic.GenerateUnivers();
                var univer = univers
                    .SingleOrDefault(u => u.Id == univerId);
                if (univer == null)
                {
                    throw new Exception($" University with Id = {univerId} " +
                                        "was not found in the database 'Univer'. ");
                }
                return Tuple
                    .Create($" The following students study at the {univer.FullName}: ",
                        univerLogic.GetUniverStudents(univerId));
            }
            catch (Exception e)
            {
                return Tuple.Create(" Error! ", new List<string> { e.Message });
            }

        }

        /// <summary>
        /// Получение списка студентов, которые учатся в университете с Name = univerName
        /// </summary>
        /// <param name="univerName"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("api/univer/studentsbyname")]
        public List<string> GetUniverStudents(string univerName)
        {
            try
            {
                UniverLogic univerLogic = new UniverLogic();
                return univerLogic.GetUniverStudents(univerName);
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }
    }
}

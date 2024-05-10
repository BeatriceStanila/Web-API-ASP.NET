using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //create an action method

        [HttpGet] //annotate the method with the HTTP GET attribute
        public IActionResult GetAllStudents()
        {
            string[] studentName = new string[] { "Jane", "Rachel", "Mark", "Izzy", "David" }; //the info will come from a DB

            return Ok(studentName); 
        }
    }
}

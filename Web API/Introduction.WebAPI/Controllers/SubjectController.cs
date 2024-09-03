using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Introduction.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : Controller
    {
        static Department MathDept = new Department(134, "Math");

        [HttpGet]
        [Route("Read/{id}")]
        public IActionResult Get(int id)
        {
            Subject? foundSubject = MathDept.FindSubject(id);
            
            if (foundSubject == null)
            {
                return BadRequest();
            }

            return Ok(foundSubject);
        }

        [HttpGet]
        [Route("ReadAll")]
        public IActionResult GetAll()
        {
            return Ok(MathDept.Subjects);
        }


        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdateSubject([Required] int id,[Required] string newName)
        {
            if(MathDept.ChangeSubjectName(id, newName) == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateSubject(Subject newSubject)
        {
            if(MathDept.AddSubject(newSubject) == true)
            {
                return Ok();
            }
            return BadRequest("Unable to add subject");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult RemoveSubject(int id)
        {
            if(MathDept.RemoveSubject(id) == true)
            {
                return Ok();
            }
            
            return BadRequest("Can't delete object");
        }

    }
}

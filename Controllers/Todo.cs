using Api1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo : ControllerBase
    {
        private readonly Context _dbContext;

        public Todo(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]   
        public IActionResult Get()
        {
            return Ok("Ok");
        }

        [HttpPost]
        public IActionResult post(Note note)
        {
           _dbContext.Note.Add(note);  
           int a=_dbContext.SaveChanges();
             if (a > 0)
            {
                return Ok(note);
            }
            else
            {
                return BadRequest("Not handle this reques");
            }
        }
    }
}

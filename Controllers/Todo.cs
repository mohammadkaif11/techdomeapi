using Api1.IReposistory;
using Api1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo : ControllerBase
    {

        private readonly IRepository<Note> _noteRepository;   

        public Todo(IRepository<Note> repository )
        {
            _noteRepository = repository;   
        }


        [HttpGet]   
        public IActionResult Get()
        {
            return Ok("Ok");
        }

        [HttpPost]
        public IActionResult post(Note note)
        {

            _noteRepository.Create(note);   
            
              return Ok(note);
           
        }
    }
}

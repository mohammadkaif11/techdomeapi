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
        public IActionResult GetAllitem()
        {
          var obj= _noteRepository.GetAll();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult post(Note note)
        {
            _noteRepository.Create(note);   
            
              return Ok(note);
           
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteRepository.Delete(id);
            return Ok("Item is delete");

        }

        [HttpPut]
        public IActionResult Put(Note note)
        {
            _noteRepository.Update(note);
            return Ok(note);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Note note = _noteRepository.GetById(id);
            return Ok(note);

        }

    }
}

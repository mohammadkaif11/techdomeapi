using Api1.IReposistory;
using Api1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo : ControllerBase
    {

        private readonly IRepository<Note> _noteRepository;

        //intialize the Note Reposistory
        public Todo(IRepository<Note> repository)
        {
            _noteRepository = repository;
        }

        //Get All Todo
        [AllowAnonymous]
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAllitem()
        {
          var obj= _noteRepository.GetAll();
            return Ok(obj);
        }

        //Add Todo 
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult post(Note note)
        {
            _noteRepository.Create(note);   
            
              return Ok(note);
           
        }
        
        //Delete Todo by id
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _noteRepository.Delete(id);
            return Ok("Item is delete");

        }

        //Update Todo By id
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Note note)
        {
            _noteRepository.Update(note);
            return Ok(note);
        }
       //Get Todo By id
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            Note note = _noteRepository.GetById(id);
            return Ok(note);

        }

    }
}

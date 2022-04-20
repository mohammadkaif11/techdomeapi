using Api1.IReposistory;
using Api1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api1.Reposistory
{
    public class NoteReposistory:IRepository<Note>
    {
        private readonly Context _dbContext;

        public NoteReposistory(Context dbContext)
        {
            _dbContext = dbContext;
        }
        public Note Create(Note _object)
        {
            _dbContext.Note.Add(_object);
            _dbContext.SaveChanges();
            return _object;
        }

        public void Delete(int id)
        {
            Note _object = _dbContext.Note.Find(id);
            _dbContext.Note.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Note> GetAll()
        {
            try
            {
                return _dbContext.Note.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Note GetById(int Id)
        {
            Note note = _dbContext.Note.Find(Id);
            return note;
        }

        public void Update(Note note)
        {
            Note obj = _dbContext.Note.Find(note.id);
            obj.Tittle = note.Tittle;
            obj.description = note.description;
            _dbContext.Note.Update(obj);
            _dbContext.SaveChanges();
        }


    }
}

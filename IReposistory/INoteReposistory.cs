using System.Collections.Generic;

namespace Api1.IReposistory
{
    public interface IRepository<T>
    {
        public T Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void Delete(int Id);

    }
}

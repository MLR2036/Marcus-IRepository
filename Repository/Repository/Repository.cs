using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private List<T> books;

        public Repository()
        {
            books = new List<T>();
        }
        public IEnumerable<T> All()
        {
            return books;
        }
        public void Delete(IComparable id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            throw new NotImplementedException();
        }       

        T IRepository<T>.FindById(IComparable id)
        {
            throw new NotImplementedException();
        }
    }
}

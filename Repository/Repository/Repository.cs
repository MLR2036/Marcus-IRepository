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
            books.RemoveAll(MatchId(id));
        }

        public void Save(T item)
        {
            if (item.Id == null)
            {
                throw new ArgumentNullException(nameof(item));
            }            
            Delete(item.Id); //ensure no duplicates
            books.Add(item);
        }

        public T FindById(IComparable id)
        {
            return books.Find(MatchId(id));
        }

        private Predicate<T> MatchId(IComparable id)
        {
            return match => match.Id.Equals(id);
        }
    }
}

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
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }
        public IEnumerable<T> All()
        {
            return items;
        }
        
        public void Delete(IComparable id)
        {           
            items.RemoveAll(MatchId(id));
        }

        public void Save(T item)
        {
            if (item == null || item.Id == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            
            var book = FindById(item.Id);
            if (book == null)
            {
                items.Add(item);
            }
            else
            {
                throw new ArgumentException("Book Id already exists");
            }
        }

        public T FindById(IComparable id)
        {
            return items.Find(MatchId(id));
        }

        private Predicate<T> MatchId(IComparable id)
        {
            return match => match.Id.Equals(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;

namespace Repository
{
    public class Book : IStoreable
    {
        public IComparable Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }       

    }
}

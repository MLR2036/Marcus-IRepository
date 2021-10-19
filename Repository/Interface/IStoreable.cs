using System;

namespace Repository.Interface
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
    }
    
}
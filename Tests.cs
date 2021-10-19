using System.Linq;
using System;
using System.Collections.Generic;
using Repository;

using NUnit.Framework;

namespace Repository.Tests
{
    [TestFixture]
    public class Tests
    {   

        [Test]
        public void Test_Repository_IEnumberable_CorrectType()
        {
            IEnumerable<Book> expected;
            Repository<Book> repository = new Repository<Book>();            
            expected = repository.All();
            Assert.IsInstanceOf<IEnumerable<Book>>(expected);
        }
    }
}
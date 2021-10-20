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
        public void Test_Repository_Returns_IEnumberable_With_CorrectType()
        {
            IEnumerable<Book> expected;
            Repository<Book> bookRepository = new Repository<Book>();            
            expected = bookRepository.All();
            Assert.IsInstanceOf<IEnumerable<Book>>(expected);
        }

        [Test]
        public void Test_Repository_Save()
        {            
            IEnumerable<Book> bookListWithSavedbook;            
            Repository<Book> bookRepository = new Repository<Book>();
            Book book = new Book { Id = 1, aurthor = "Ian Felming", Title = "Casino Royal" };
            Book duplicateBook = new Book { Id = 1, aurthor = "Ian Felming", Title = "Casino Royal" };
            bookRepository.Save(book);
            bookRepository.Save(duplicateBook);
            bookListWithSavedbook = bookRepository.All();
            int listCount = bookListWithSavedbook.Count();
            int count = 1;
            Assert.IsTrue(bookListWithSavedbook.Contains(duplicateBook));
            Assert.IsTrue(listCount == count);
        }

        [Test]
        public void Test_Repository_Save_ThrowsException_IfNoID()
        {
            Repository<Book> bookRepository = new Repository<Book>();
            Book book = new Book();
            var exception = Assert.Throws<ArgumentNullException>(() => bookRepository.Save(book));

            Assert.AreEqual("item", exception.ParamName);
        }

        [Test]
        public void Test_Repository_Delete()
        {
            IEnumerable<Book> emptyBookList;
            Repository<Book> bookRepository = new Repository<Book>();
            Book bookToBeDeleted = new Book() { Id = 1, aurthor = "Ian Felming", Title = "Casino Royal" };

            bookRepository.Save(bookToBeDeleted);
            bookRepository.Delete(1);
            emptyBookList = bookRepository.All();

            Assert.IsFalse(emptyBookList.Contains(bookToBeDeleted));

        }

        [Test]
        public void Test_Repository_FindById()
        {
            Book bookFound;
            Repository<Book> bookRepository = new Repository<Book>();
            List<Book> bookList = new List<Book>
            {
                new Book {Id=1, aurthor="Ian Fleming", Title = "Casino Royal" },
                new Book {Id=2, aurthor="Ian Fleming", Title = "The Man with the Golden Gun" },
                new Book {Id=3, aurthor="Ian Fleming", Title = "From Russia with Love" },
                new Book {Id=4, aurthor="Ian Fleming", Title = "Live and Let Die" }
            };

            foreach (var book in bookList)
            {
                bookRepository.Save(book);                
            }

            bookFound = bookRepository.FindById(3);
            Book bookId3 = bookList.ElementAt(2);
            Assert.AreEqual(bookId3, bookFound);
        }
    }
}
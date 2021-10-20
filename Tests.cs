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
        private Repository<Book> bookRepository;

        [SetUp]
        public void Setup()
        {
            bookRepository = new Repository<Book>();            
        }

        [Test]
        public void Test_Repository_Returns_IEnumberable_With_CorrectType()
        {
            // Arrange
            IEnumerable<Book> books;

            // Act
            books = bookRepository.All();

            // Assert
            Assert.IsInstanceOf<IEnumerable<Book>>(books);
        }

        [Test]
        public void Test_Repository_Save()
        {
            // Arrange
            IEnumerable<Book> savedBookList;
            Book book = new Book 
            { 
                Id = 1,
                Author = "Ian Felming",
                Title = "Casino Royal"
            };            

            // Act
            bookRepository.Save(book);            
            savedBookList = bookRepository.All();       

            //Assert
            Assert.IsTrue(savedBookList.Contains(book));            
        }

        [Test]
        public void Test_Repository_Saves_NoDuplicates()
        {
            // Arrange
            IEnumerable<Book> savedBookList;
            Book book = new Book
            {
                Id = 1,
                Author = "Ian Felming",
                Title = "Casino Royal"
            };

            Book duplicateBook = new Book
            {
                Id = 1,
                Author = "Ian Felming",
                Title = "Casino Royal"
            };

            //Act and Assert
            bookRepository.Save(book);
            var exception = Assert.Throws<ArgumentException>(() => bookRepository.Save(duplicateBook));

            savedBookList = bookRepository.All();

            Assert.AreEqual("Book Id already exists", exception.Message);           
            Assert.IsFalse(savedBookList.Contains(duplicateBook));
        }

        [Test]
        public void Test_Repository_Save_ThrowsException_IfNoID()
        {           
            //Arrange
            Book book = new Book();

            //Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => bookRepository.Save(book));

            Assert.AreEqual("item", exception.ParamName);
        }

        [Test]
        public void Test_Repository_Delete()
        {
            //Arrange
            IEnumerable<Book> emptyBookList;           
            Book bookToBeDeleted = new Book
            { 
                Id = 1, 
                Author = "Ian Felming",
                Title = "Casino Royal" 
            };

            //Act
            bookRepository.Save(bookToBeDeleted);
            bookRepository.Delete(1);
            emptyBookList = bookRepository.All();

            //Assert
            Assert.IsFalse(emptyBookList.Contains(bookToBeDeleted));
        }

        [Test]
        public void Test_Repository_FindById()
        {
            //Arrange
            Book actualBookFound;
            List<Book> bookList = GetTestBookList();

            //Act
            foreach (var book in bookList)
            {
                bookRepository.Save(book);                
            }

            actualBookFound = bookRepository.FindById(3);
            Book bookToFind = bookList.ElementAt(2);

            //Assert
            Assert.AreEqual(bookToFind, actualBookFound);
        }

        private List<Book> GetTestBookList()
        {
            return new List<Book>             
            {
                new Book 
                {
                    Id = 1,
                    Author = "Ian Fleming",
                    Title = "Casino Royal"
                },
                new Book 
                {
                    Id = 2,
                    Author = "Ian Fleming",
                    Title = "The Man with the Golden Gun"
                },
                new Book 
                {
                    Id = 3,
                    Author = "Ian Fleming",
                    Title = "From Russia with Love"
                },
                new Book
                {
                    Id = 4,
                    Author = "Ian Fleming",
                    Title = "Live and Let Die"
                }
            };
        }
    }
}
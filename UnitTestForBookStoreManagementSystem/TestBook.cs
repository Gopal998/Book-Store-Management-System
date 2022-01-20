using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.DataAccessLayer;
using BookStore.BusinessLogicLayer;
using BookStore.PresentationLayer.Controllers;
using BookStore.Entity;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;

namespace UnitTestForBookStoreManagementSystem
{
    [TestClass]
    public class TestBook
    {
        [TestMethod]
        public async Task TestAddBook()
        {
            var mock = new Mock<IBookDAL>();
            Book book = new Book()
            {
                BookName = "abc",
                Author = "xya",
                Publisher = "ajf",
                Cost = 400,
                AvailableFor = "rent",
                Quantity = 5

            };
            mock.Setup(p => p.AddBook(book)).ReturnsAsync(true);
            BookBLL bl = new BookBLL(mock.Object);
            var result = await bl.AddBook(book);

            Assert.AreEqual(result, true);
        }



            /*BookStoreDBContext context = new BookStoreDBContext();

            BookDAL bookDAL = new BookDAL(context);
            BookBLL bookBLL = new BookBLL(bookDAL);
            Book book = new Book()
            {

                BookName = "abc",
                Author = "xya",
                Publisher = "ajf",
                Cost = 400,
                AvailableFor = "rent",
                Quantity = 5*/

            /*  };

              var actual = await bookBLL.AddBook(book);
              Assert.AreEqual(actual, true);
                  }*/
            [TestMethod]
        public async Task TestCountForSaleOrRent()
        {
            BookStoreDBContext context = new BookStoreDBContext();

            BookDAL bookDAL = new BookDAL(context);
            BookBLL bookBLL = new BookBLL(bookDAL);

            var actual = await bookBLL.CountForSaleOrRent("sale");
            Assert.AreEqual(actual, 3);
        }
    }
}

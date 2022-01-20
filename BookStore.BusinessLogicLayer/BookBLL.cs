using BookStore.DataAccessLayer;
using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public class BookBLL:IBookBLL
    {
        private readonly IBookDAL _bookDAL;
        public BookBLL(IBookDAL book)
        {
            _bookDAL = book;
        }
        public async Task<bool> AddBook(Book book)
        {
            return await _bookDAL.AddBook(book);
        }
        public async Task<List<Book>> CountForSaleOrRent(string avail)
        {
            return await _bookDAL.CountForSaleOrRent(avail);
        }
        public async Task<List<Book>> GetBookForSale()
        {
            return await _bookDAL.GetBookForSale();
        }
        public async Task<List<Book>> GetBookForRent()
        {
            return await _bookDAL.GetBookForRent();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            return await _bookDAL.UpdateBook(book);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookDAL.DeleteBook(id);
        }

        public async Task<List<Book>> GetNotSelectedBook()
        {
            return await _bookDAL.GetNotSelectedBook();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookDAL.GetBookById(id);
        }
    }
}

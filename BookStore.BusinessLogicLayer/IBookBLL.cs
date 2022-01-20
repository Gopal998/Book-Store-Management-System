using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public interface IBookBLL
    {
        Task<bool> AddBook(Book book);
        Task<List<Book>> CountForSaleOrRent(string avail);
        Task<List<Book>> GetBookForSale();
        Task<List<Book>> GetBookForRent();
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<List<Book>> GetNotSelectedBook();
        Task<Book> GetBookById(int id);
    }
}

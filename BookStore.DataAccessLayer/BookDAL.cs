using BookStore.CustomException;
using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer
{
    public class BookDAL : IBookDAL
    {
        private readonly BookStoreDBContext _dbContext;

        public BookDAL(BookStoreDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> AddBook(Book book)
        {
            if (await _dbContext.Books.FirstOrDefaultAsync(b => b.BookName == book.BookName) != null)
            {
                throw new DuplicateNameException("Name already Exists");
            }
            else
            {
                try
                {
                    int rowAffected = 0;
                    _dbContext.Add(book);
                    rowAffected = await _dbContext.SaveChangesAsync();
                    if (rowAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new SqlException("Something went Wrong", e);
                }
            }
        }
        public async Task<List<Book>> CountForSaleOrRent(string avail)
        {
            try
            {
                return await _dbContext.Books.Where(b => b.AvailableFor.Equals(avail) == true && b.Quantity > 0).ToListAsync();
            }
            catch (Exception e)
            {
                throw new SqlException("Something went Wrong", e);
            }
        }
        public async Task<Book> GetBookById(int id)
        {
            try
            {
                return await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);
            }
            catch (Exception e)
            {
                throw new SqlException("Something went Wrong", e);
            }
        }
        public async Task<List<Book>> GetBookForSale()
        {
            try
            {
                return await _dbContext.Books.Where(b => b.AvailableFor.Equals("sale") == true && b.Quantity > 0).ToListAsync();
            }
            catch (Exception e)
            {
                throw new SqlException("Something went Wrong", e);
            }
        }
        public async Task<List<Book>> GetBookForRent()
        {
            try
            {
                return await _dbContext.Books.Where(b => b.AvailableFor.Equals("rent") == true && b.Quantity > 0).ToListAsync();
            }
            catch (Exception e)
            {
                throw new SqlException("Something went Wrong", e);
            }
        }
        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                Book oldBook = await _dbContext.Books.FirstOrDefaultAsync(s => s.BookId == book.BookId);
                oldBook.BookName = book.BookName;
                oldBook.Author = book.Author;
                oldBook.Cost = book.Cost;
                oldBook.Publisher = book.Publisher;
                oldBook.Quantity = book.Quantity;
                oldBook.AvailableFor = book.AvailableFor;

                int rowAffected = 0;
                rowAffected = await _dbContext.SaveChangesAsync();
                if (rowAffected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new SqlException("Something went wrong", e);
            }
        }
        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                Book book = await _dbContext.Books.FirstOrDefaultAsync(t => t.BookId == id);
                if (book != null)
                {
                    int rowAffected = 0;
                    _dbContext.Remove(book);
                    rowAffected = await _dbContext.SaveChangesAsync();
                    if (rowAffected != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new SqlException("Something went Wrong", e);

            }
        }
        public async Task<List<Book>> GetNotSelectedBook()
        {
            int flag = 0;
            List<Book> notSelectedBook = new List<Book>();
            List<Transaction> transactions = await _dbContext.Transactions.ToListAsync();
            List<Book> books = await _dbContext.Books.ToListAsync();
            foreach (var bookItem in books)
            {
                foreach (var transactionItem in transactions)
                {
                    if(bookItem.BookId == transactionItem.BookId)
                    {
                        flag = 1;
                    }
                }
                if(flag == 0)
                {
                    notSelectedBook.Add(bookItem);
                }
                else
                {
                    flag = 0;
                }
            }
            return notSelectedBook;
        }
    }
}

using BookStore.CustomException;
using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer
{
    public class TransactionDAL:ITransactionDAL
    {
        private readonly BookStoreDBContext _dbContext;

        public TransactionDAL(BookStoreDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> AddTransaction(Transaction transaction)
        {
            try
            {
                Book book = await _dbContext.Books.FirstOrDefaultAsync(s => s.BookId == transaction.BookId);
                if (book.Quantity > transaction.Quantity)
                {
                    int rowAffected = 0;
                    _dbContext.Add(transaction);
                    rowAffected = await _dbContext.SaveChangesAsync();
                    int updateRow = 0;
                    book.Quantity = book.Quantity - transaction.Quantity;
                    updateRow = await _dbContext.SaveChangesAsync();
                    if (rowAffected > 0 && updateRow > 0)
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
                    throw new BookNotAvailableException("Book out of Stock!!");
                }
            }
            catch(SqlException e)
            {
                throw new SqlException("Something went wrong", e);
            }
        }
        public async Task<bool> ReturnRentedBook(int id , int days)
        {
            Transaction transaction = await _dbContext.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
            
            if(transaction == null)
            {
                throw new InvalidTransactionIDException("Invalid transactionID!!");
            }
            if(transaction.AvailedAs.Equals("rent"))
            {
                int rowAff = 0;
                _dbContext.Remove(transaction);
                Book book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == transaction.BookId);
                book.Quantity += transaction.Quantity; 
                rowAff = await _dbContext.SaveChangesAsync();
                if (days > 14)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                throw new InvalidTransactionIDException("Invalid transactionID!!");
            }
        }
        public async  Task<List<Transaction>> GetTransactions()
        {
            try
            {
                return await _dbContext.Transactions.ToListAsync();
            }
            catch (SqlException e)
            {
                throw new SqlException("Something went wrong", e);
            }
        }
    }
}

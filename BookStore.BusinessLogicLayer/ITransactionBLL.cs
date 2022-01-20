using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public interface ITransactionBLL
    {
        Task<bool> AddTransaction(Transaction transaction);
        Task<bool> ReturnRentedBook(int id, int days);
        Task<List<Transaction>> GetTransactions();
    }
}

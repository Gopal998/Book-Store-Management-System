using BookStore.DataAccessLayer;
using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public class TransactionBLL:ITransactionBLL
    {
        private readonly ITransactionDAL _transactionDAL;
        public TransactionBLL(ITransactionDAL transactionDAL)
        {
            _transactionDAL = transactionDAL;
        }
        public async Task<bool> AddTransaction(Transaction transaction)
        {
            return await _transactionDAL.AddTransaction(transaction);
        }

        public async Task<bool> ReturnRentedBook(int id, int days)
        {
            return await _transactionDAL.ReturnRentedBook(id, days);
        }
        public async Task<List<Transaction>> GetTransactions()
        {
            return await _transactionDAL.GetTransactions();
        }
    }
}

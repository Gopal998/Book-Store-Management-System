using BookStore.BusinessLogicLayer;
using BookStore.CustomException;
using BookStore.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionBLL _transactionBLL;
        public TransactionController(ITransactionBLL transaction)
        {
            _transactionBLL = transaction;
        }
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            try
            {
                return Ok(await _transactionBLL.AddTransaction(transaction));
            }
            catch(BookNotAvailableException e)
            {
                return BadRequest(e.Message);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("CheckFine")]
        public async Task<IActionResult> ReturnRentedBook(int id, int days)
        {
            try
            {
                bool ret = await _transactionBLL.ReturnRentedBook(id, days);
                if (ret)
                {
                    return Ok("You have to Pay Rs.10 fine for late submission!!");
                }
                else
                {
                    return Ok("You have no Fine!!!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetTransaction")]
        public async Task<IActionResult> GetTransaction()
        {
            try
            {
                return Ok(await _transactionBLL.GetTransactions());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

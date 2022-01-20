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
    public class BookController : ControllerBase
    {
        private readonly IBookBLL _bookBLL;
        public BookController(IBookBLL bookBLL)
        {
            _bookBLL = bookBLL;
        }
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(Book book)
        {
            try
            {
                return Ok(await _bookBLL.AddBook(book));
            }
            catch (DuplicateNameException e)
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
        [HttpGet("GetCountOFBook")]
        public async Task<IActionResult> CountForSaleOrRent(string avail)
        {
            try
            {
                List<Book> books = await _bookBLL.CountForSaleOrRent(avail);
                return Ok(books.Count);
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
        [HttpGet("GeBookForRent")]
        public async Task<IActionResult> GetBookForRent()
        {
            try
            {
                List<Book> books = await _bookBLL.GetBookForRent();
                return Ok(books);
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
        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _bookBLL.GetBookById(id));
        }
        [HttpGet("GetBookForSale")]
        public async Task<IActionResult> GetBookForSale()
        {
            try
            {
                List<Book> books = await _bookBLL.GetBookForSale();
                return Ok(books);
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

        [HttpPost("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            try
            {
                return Ok(await _bookBLL.UpdateBook(book));
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
        [HttpPost("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                return Ok(await _bookBLL.DeleteBook(id));
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
        [HttpGet("GetNotSelectedBook")]
        public async Task<IActionResult> GetNotSelectedBook()
        {
            try
            {
                List<Book> books = await _bookBLL.GetNotSelectedBook();
                return Ok(books);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

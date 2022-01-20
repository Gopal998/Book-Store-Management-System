using BookStoreMVC.HttpHelpers;
using Microsoft.AspNetCore.Mvc;
using BookStore.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;


namespace BookStoreMVC.Controllers
{
    public class BookController : Controller
    {
        BookStoreAPI bookStoreAPI = new BookStoreAPI();
        public async Task<IActionResult> Index()
        {
            List<Book> books = new List<Book>();
            HttpClient client = bookStoreAPI.Initial();
            HttpResponseMessage responseMessage = await client.GetAsync("api/Book/GetBookForSale");
            if(responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(result);
            }

            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if (id == 0)
                return View(new Book());
            else
            {
                Book book = new Book();
                HttpClient client = bookStoreAPI.Initial();
                HttpResponseMessage responseMessage = await client.GetAsync($"api/Book/GetBookById/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<Book>(result);
                }
                return View(book);
            }
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            HttpClient client = bookStoreAPI.Initial();
            HttpResponseMessage postMessage;
            if(book.BookId == 0)
            {
                postMessage = client.PostAsJsonAsync<Book>("api/Book/AddBook", book).Result;
            }
            else
            {
                postMessage = client.PostAsJsonAsync<Book>("api/Book/UpdateBook", book).Result;
            }
            if(postMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Server Error!");
            return View(new Book());
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            HttpClient client = bookStoreAPI.Initial();
            HttpResponseMessage postMessage = await client.DeleteAsync($"api/Book/DeleteBook/{id}");


            if (postMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Server Error!");
            return View();
        }
    }
}

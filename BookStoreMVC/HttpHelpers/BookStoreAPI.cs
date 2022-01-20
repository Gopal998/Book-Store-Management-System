using System;
using System.Net.Http;


namespace BookStoreMVC.HttpHelpers
{
    public class BookStoreAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:49461");
            return Client;
        }
    }
}

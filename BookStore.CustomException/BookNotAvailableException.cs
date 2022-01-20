using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CustomException
{
    public class BookNotAvailableException : Exception
    {
        public BookNotAvailableException()
        {

        }
        public BookNotAvailableException(string message) : base(message)
        {

        }
        public BookNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CustomException
{
    public class DuplicateNameException : Exception
    {
        public DuplicateNameException()
        {

        }
        public DuplicateNameException(string message) : base(message)
        {

        }
        public DuplicateNameException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

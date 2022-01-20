using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CustomException
{
    
    public class InvalidTransactionIDException : Exception
    {

        public InvalidTransactionIDException()
        {

        }
        public InvalidTransactionIDException(string message) : base(message)
        {

        }
        public InvalidTransactionIDException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

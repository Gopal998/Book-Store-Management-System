using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CustomException
{
    public class SqlException : Exception
    {

        public SqlException()
        {

        }
        public SqlException(string message) : base(message)
        {

        }
        public SqlException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

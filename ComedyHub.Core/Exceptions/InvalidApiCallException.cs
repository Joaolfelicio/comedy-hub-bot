using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ComedyHub.Core.Exceptions
{
    public class InvalidApiCallException : Exception
    {
        public InvalidApiCallException()
        {
        }
        public InvalidApiCallException(string apiUrl, HttpStatusCode statusCode)
               : base(String.Format($"Call to: {apiUrl} returned the status code: {statusCode}"))
        {
        }
    }
}

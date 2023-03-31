using System;
using System.Collections.Generic;
using System.Text;


namespace Insurance.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        { 
        }
    }
}

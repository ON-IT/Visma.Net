using System;

namespace ONIT.VismaNetApi.Exceptions
{
    public class InvalidArgumentsException : Exception
    {
        public InvalidArgumentsException(string message) : base(message)
        {
            
        }
    }
}
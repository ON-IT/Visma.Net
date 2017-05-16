using System;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Exceptions
{
    public class InvalidTokenException : VismaNetException
    {
        public InvalidTokenException(VismaNetExceptionDetails exceptionDetails) : base(exceptionDetails)
        {
        }

        public InvalidTokenException(VismaNetExceptionDetails exceptionDetails, Exception innerException)
            : base(exceptionDetails, innerException)
        {
        }
    }
}
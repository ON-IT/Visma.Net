using System;

namespace ONIT.VismaNetApi.Lib
{
    public class VismaNetException : Exception
    {
        public VismaNetException(VismaNetExceptionDetails exceptionDetails)
            : base(exceptionDetails.DetailsMessage)
        {
            Details = exceptionDetails;
        }

        public VismaNetException(VismaNetExceptionDetails exceptionDetails, Exception innerException)
            : base(exceptionDetails.DetailsMessage, innerException)
        {
            Details = exceptionDetails;
        }

        public VismaNetExceptionDetails Details { get; private set; }
    }
}
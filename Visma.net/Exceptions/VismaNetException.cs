using ONIT.VismaNetApi.Lib;
using System;

namespace ONIT.VismaNetApi.Exceptions
{
    public class VismaNetException : Exception
    {
        public VismaNetException(VismaNetExceptionDetails exceptionDetails)
            : base(exceptionDetails.DetailsMessage)
        {
            Details = exceptionDetails;
        }

        public VismaNetException(VismaNetExceptionDetails exceptionDetails, Exception innerException)
            : base(exceptionDetails?.DetailsMessage, innerException)
        {
            Details = exceptionDetails;
        }

        public VismaNetExceptionDetails Details { get; private set; }
        public string Payload { get; set; }
        public string Endpoint { get; set; }
    }
}
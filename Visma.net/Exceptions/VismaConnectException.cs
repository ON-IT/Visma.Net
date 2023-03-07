using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Exceptions
{
    public class VismaConnectException : Exception
    {
        private string _jsonResult;
        public string jsonResult { get { return _jsonResult; } }
        public VismaConnectException() { }
        public VismaConnectException(string message) : base(message) { }
        public VismaConnectException(string message, Exception inner) : base(message, inner) { }

        public VismaConnectException(string message, string jsonResult) : base(message)
        {
            _jsonResult= jsonResult;
        }
    }
}

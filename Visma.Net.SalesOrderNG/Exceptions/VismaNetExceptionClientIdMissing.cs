using System;
using System.Collections.Generic;
using System.Text;

namespace Visma.Net.SalesOrderNG.Exceptions
{
    internal class VismaNetExceptionClientIdMissing : System.Exception
    {
        public VismaNetExceptionClientIdMissing() { }
        public VismaNetExceptionClientIdMissing(string message) : base(message) { }
        public VismaNetExceptionClientIdMissing(string message, Exception inner) : base(message, inner) { }
    }
}

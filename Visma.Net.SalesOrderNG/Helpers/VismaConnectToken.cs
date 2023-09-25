using System;

namespace Visma.Net.SalesOrderNG
{
    public class VismaConnectToken
    {
        public string access_token { get; set; }
        public DateTimeOffset expires_on { get; set; }
    }
}
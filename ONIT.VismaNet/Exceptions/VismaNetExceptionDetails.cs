namespace ONIT.VismaNetApi.Lib
{
    public class VismaNetExceptionDetails
    {
        public string FaultCode { get; set; }
        public string ExceptionMessageID { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionDetails { get; set; }
        public string ExceptionType { get; set; }
        public string message { get; set; }

        public string DetailsMessage
        {
            get { return message ?? string.Format("{0} {1}", ExceptionMessage, ExceptionDetails); }
        }
    }
}
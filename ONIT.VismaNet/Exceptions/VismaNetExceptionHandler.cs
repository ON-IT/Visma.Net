using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi
{
    public static class VismaNetExceptionHandler
    {
        public static void HandleException(AggregateException exception)
        {
            var webException = exception.InnerException as WebException;
            if (webException == null)
                throw exception.InnerException;
            HandleException(webException);

        }

        public static void HandleException(WebException exception)
        {
            if (exception.Response != null)
            {
                WebResponse response = exception.Response;
                Stream stream = response.GetResponseStream();
                if (stream != null)
                {
                    string data = new StreamReader(stream).ReadToEnd();
                    var details = JsonConvert.DeserializeObject<VismaNetExceptionDetails>(data);
                    throw new VismaNetException(details);
                }
            }
        }
    }
}
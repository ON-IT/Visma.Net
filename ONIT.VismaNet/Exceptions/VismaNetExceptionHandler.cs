using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi
{
    internal static class VismaNetExceptionHandler
    {
        internal static void HandleException(AggregateException exception)
        {
            var webException = exception.InnerException as WebException;
            if (webException == null)
                throw exception.InnerException;
            HandleException(webException);
        }

        internal static void HandleException(VismaNetException e)
        {
            throw e;
        }

        internal static void HandleException(WebException exception)
        {
            if (exception.Response != null)
            {
                var response = exception.Response;
                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                        HandleException(stream, exception);
                }
            }
        }

        internal static void HandleException(Stream stream, Exception e = null)
        {
            HandleException(new StreamReader(stream).ReadToEnd(), e);
        }

        internal static void HandleException(string data, Exception e = null)
        {
            ThrowException(data, e);
        }

        private static void ThrowException(string data, Exception ex = null)
        {
            var details = JsonConvert.DeserializeObject<VismaNetExceptionDetails>(data);

            if (details.ExceptionMessage.IndexOf("companyincontext", StringComparison.OrdinalIgnoreCase) > -1 ||
                details.ExceptionMessage.IndexOf("token", StringComparison.OrdinalIgnoreCase) > -1)
                throw new InvalidTokenException(details, ex);

            throw new VismaNetException(details, ex);
        }
    }
}
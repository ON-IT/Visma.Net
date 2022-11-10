using Newtonsoft.Json;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Lib;
using System;
using System.IO;
using System.Net;

namespace ONIT.VismaNetApi
{
    internal static class VismaNetExceptionHandler
    {
        internal static void HandleException(AggregateException exception, string request = null, string endpoint = null)
        {
            var webException = exception.InnerException as WebException;
            if (webException == null)
                throw exception.InnerException;
            HandleException(webException, request, endpoint);
        }

        internal static void HandleException(VismaNetException e)
        {
            throw e;
        }

        internal static void HandleException(WebException exception, string request = null, string endpoint = null)
        {
            if (exception.Response != null)
            {
                var response = exception.Response;
                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                        HandleException(stream, exception, request, endpoint);
                }
            }
        }

        internal static void HandleException(Stream stream, Exception e = null, string request = null, string endpoint = null)
        {
            HandleException(new StreamReader(stream).ReadToEnd(), e, request, endpoint);
        }

        internal static void HandleException(string data, Exception e = null, string request = null, string endpoint = null)
        {
            ThrowException(data, e, request);
        }

        private static void ThrowException(string data, Exception ex = null, string request = null, string endpoint = null)
        {
            var details = JsonConvert.DeserializeObject<VismaNetExceptionDetails>(data);

            if (details?.ExceptionMessage != null)
            {
                if (details.ExceptionMessage.IndexOf("companyincontext", StringComparison.OrdinalIgnoreCase) > -1 ||
                    details.ExceptionMessage.IndexOf("token", StringComparison.OrdinalIgnoreCase) > -1)
                    throw new InvalidTokenException(details, ex);
            }
            throw new VismaNetException(details, ex)
            {
                Payload = request,
                Endpoint = endpoint
            };
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace WebApplication1.Exceptions
{
    public class BaseException : Exception
    {
        private Error Error { get; set; }
        private HttpStatusCode StatusCode { get; set; }

        public BaseException(string errorCode, string message, HttpStatusCode statusCode, Exception? ex) : base(message, ex)
        {
            StatusCode = statusCode;
            Error = new Error(errorCode, message);
        }

        public IActionResult GetResponse()
        {
            return new ContentResult
            {
                StatusCode = ((int)StatusCode),
                Content = JsonConvert.SerializeObject(Error, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() })
            };
        }
    }

    public class Error
    {
        public Error(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}

using System.Net;
using WebApplication1.Exceptions;

namespace AspNetCore.Exceptions
{
    public class CityNotFoundException : BaseException
    {
        public CityNotFoundException(string message) : base("BI:0001", message, HttpStatusCode.NotFound, null) { }
        public CityNotFoundException(string message, Exception ex) : base("BI:0001", message, HttpStatusCode.NotFound, ex) { }
    }
}

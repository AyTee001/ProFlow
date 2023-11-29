using ProFlow.Core.Common.Exceptions;
using ProFlow.Core.DAL.Exceptions;
using System.Net;

namespace ProFlow.Core.WebAPI.Extensions
{
    public static class ExceptionFilterExtensions
    {
        public static (HttpStatusCode statusCode, int errorCode) ParseException(this Exception exception)
        {
            return exception switch
            {
                NotFoundException _ => (HttpStatusCode.NotFound, 404),
                PreconditionFailedException _ => (HttpStatusCode.PreconditionFailed, 412),
                ArgumentNullException _ => (HttpStatusCode.BadRequest, 400),
                _ => (HttpStatusCode.InternalServerError, 500),
            };
        }

    }
}

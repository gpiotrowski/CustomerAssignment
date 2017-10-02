using System;
using System.Net;
using CustomerAssignment.Common.API.Responses;
using CustomerAssignment.Customers.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BaseErrorHandlingMiddleware = CustomerAssignment.Common.API.Middlewares.ErrorHandlingMiddleware;

namespace CustomerAssignment.Customers.API.Middlewares
{
    public class ErrorHandlingMiddleware : BaseErrorHandlingMiddleware
    {
        public ErrorHandlingMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override (HttpStatusCode statusCode, string exceptionResponse) HandleException(Exception exception)
        {
            HttpStatusCode code;
            string result;

            switch (exception)
            {
                case ClientAlreadyDeletedException ex:
                    code = HttpStatusCode.Forbidden;
                    var exceptionResponse = new ExceptionResponse()
                    {
                        Error = ex.Message
                    };

                    result = JsonConvert.SerializeObject(exceptionResponse);
                    break;
                default:
                    return base.HandleException(exception);
            }

            return (code, result);
        }
    }
}

using System;
using System.Net;
using System.Threading.Tasks;
using CustomerAssignment.Common.Application.Exceptions;
using CustomerAssignment.Common.API.Responses;
using CustomerAssignment.Common.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CustomerAssignment.Common.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var handledExceptionResult = HandleException(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)handledExceptionResult.statusCode;
            return context.Response.WriteAsync(handledExceptionResult.exceptionResponse);
        }

        protected virtual (HttpStatusCode statusCode, string exceptionResponse) HandleException(Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            string result = String.Empty;
            ExceptionResponse exceptionResponse;

            switch (exception)
            {
                case InvalidRequestPropertiesException ex:
                    code = HttpStatusCode.BadRequest;
                    exceptionResponse = new ExceptionResponse()
                    {
                        Error = ex.Message,
                        Details = ex.FailedValidationResults
                    };

                    result = JsonConvert.SerializeObject(exceptionResponse);
                    break;
                case AggregateNotFoundException ex:
                    code = HttpStatusCode.NotFound;
                    exceptionResponse = new ExceptionResponse()
                    {
                        Error = ex.Message
                    };

                    result = JsonConvert.SerializeObject(exceptionResponse);
                    break;
            }

            return (code, result);
        }
    }
}

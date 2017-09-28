﻿using System;
using System.Net;
using System.Threading.Tasks;
using CustomerAssignment.Common.Application.Exceptions;
using CustomerAssignment.Common.API.Responses;
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            string result = String.Empty;

            switch (exception)
            {
                case InvalidRequestPropertiesException ex:
                    code = HttpStatusCode.BadRequest;
                    var exceptionResponse = new ExceptionResponse()
                    {
                        Error = ex.Message,
                        Details = ex.FailedValidationResults
                    };

                    result = JsonConvert.SerializeObject(exceptionResponse);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
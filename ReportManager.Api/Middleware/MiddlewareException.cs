using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReportManager.Domain.Exceptions;

namespace ReportManager.Api.Middleware
{
    public class MiddlewareException
    {
        private RequestDelegate _next;
        public MiddlewareException(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (TooBigReportException ex) 
            {
                //add some logic
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } 
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

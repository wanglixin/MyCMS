using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCMS.Infrastructure.Core;

namespace MyCMS.API.Exceptions
{
    public class CustomerExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            IKnownException knownException = context.Exception as IKnownException;
            if (knownException == null)
            {
                var logger = context.HttpContext.RequestServices.GetService<ILogger<CustomerExceptionFilter>>();
                logger.LogError(context.Exception, context.Exception.Message);
                // knownException = KnownException.Unknown;
                knownException = KnownException.FromKnownException(context.Exception);
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            else
            {
                knownException = KnownException.FromKnownException(knownException);
                context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            }
            context.Result = new JsonResult(Result<object[]>.Instance(knownException.ErrorData, knownException.Message, knownException.ErrorCode)) //断路器
            {
                ContentType = "application/json; charset=utf-8"
            };


        }
    }
}

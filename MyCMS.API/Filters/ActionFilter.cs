using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyCMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCMS.API.Filters
{
    public class ActionFilter : IActionFilter
    {
        /// <summary>
        /// action执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        /// <summary>
        ///  action执行前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //校验参数
            if (!context.ModelState.IsValid)
            {
                var errorMsg = string.Join(";", context.ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                context.Result = new JsonResult(Result.Instance(string.IsNullOrWhiteSpace(errorMsg) ? "参数校验错误" : errorMsg, -1));
            }
        }
    }
}

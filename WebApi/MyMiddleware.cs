using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class MyMiddleware
    {
        readonly RequestDelegate _requestDelegate;
        public MyMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity.Name=="张三")
            {
                await _requestDelegate.Invoke(context);
            }
            await context.Response.WriteAsync("noAuth");
        }
    }
}

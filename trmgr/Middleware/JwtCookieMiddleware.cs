﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Middleware
{
    public class JwtCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var accessTokenCookie = context.Request.Cookies["access_token"];
            if (accessTokenCookie != null)
            {
                context.Request.Headers.Remove("Authorization");
                context.Request.Headers.Append("Authorization", $"Bearer {accessTokenCookie}");
            }
            await _next.Invoke(context);
        }
    }
}

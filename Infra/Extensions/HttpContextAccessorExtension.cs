using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trello_.Extensions
{
    public static class HttpContextAccessorExtension
    {
        public static string GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            //get ID from token in Jwtservice class
            var cl = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault();
            return cl.Value;
        }

    }
}

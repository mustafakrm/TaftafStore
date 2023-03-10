using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace WebAPPCoreMvcUI.CustomFilterAttribute
{
    
    public class MyCustomAttribute : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Cookies.ContainsKey("exp_ti"))
            {
                if (DateTime.Parse(context.HttpContext.Request.Cookies["exp_ti"]) >= DateTime.Now)
                {
                    //not working
                    //var token = context.HttpContext.Request.Cookies["Token"];
                    //context.HttpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
                    return;
                }

            }

            RedirectToLogin(context);
        }

        private void RedirectToLogin(ActionExecutingContext context)
        {
            var redirectTarget = new RouteValueDictionary
            {
                {"action","Login" },
                {"controller", "Auth" }
            };

            context.Result = new RedirectToRouteResult(redirectTarget);
        }
    }
   
}

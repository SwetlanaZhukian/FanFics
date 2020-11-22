using Fanfic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Fanfic.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fanfic.Filters
{
    public class DeletedUserFilter: Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;
            if (AdministratorService.DeletedUsers.ContainsKey(user.Identity.Name))
            {
                context.HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
                AdministratorService.DeletedUsers.Remove(user.Identity.Name);
                context.Result = new RedirectResult("/Account/Login");
            }

        }

     
    }
}

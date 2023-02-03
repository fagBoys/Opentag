using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vira.Core.Services;
using Vira.Core.Services.Interfaces;
using Vira.DataLayer.Context;

namespace Vira.Core.Security
{
    public class PermissionChekerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IPermissionService _permissionService;
        private int _permissionId = 0;
        public PermissionChekerAttribute( int permissionId)
        {
            _permissionId = permissionId;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService)); 
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string UserName = context.HttpContext.User.Identity.Name;
                if (!_permissionService.CheckPermission(_permissionId,UserName))
                {
                    context.Result = new RedirectResult("/Login?"+context.HttpContext.Request.Path);

                }
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}

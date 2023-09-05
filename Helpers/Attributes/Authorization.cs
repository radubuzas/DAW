using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Enums;

namespace WebApplication1.Helpers.Attributes;

public class Authorization : Attribute, IAuthorizationFilter
{
    private readonly ICollection<Role> _roles;
    
    public Authorization(params Role[] roles)
    {
        _roles = roles;
    }
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var unauthorizedStatusObject = new JsonResult(new {message = "Unauthorized"})
            {StatusCode = StatusCodes.Status401Unauthorized};

        if (_roles == null)
        {
            context.Result = unauthorizedStatusObject;
        }
        
        var user = (Utilizator)context.HttpContext.Items["User"];
        
        if( user == null || !_roles.Contains(user.Role))
        {
            context.Result = unauthorizedStatusObject;
        }
    }

}
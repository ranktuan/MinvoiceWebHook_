using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        string token = actionContext.Request.Headers.Authorization?.Parameter;
        if (IsValidToken(token))
        {
            base.OnAuthorization(actionContext);
        }
        else
        {           
            actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }
    }
    private bool IsValidToken(string token)
    {
        return token == "khsffjdhsfhjklslhgdlsfdlsjhggflhffsdfhdgjkfgkfdsfjldghslogfsa";


    }
}

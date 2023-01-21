using System.Text.Json;
using cdf_api_integrador.DTOs;
using Microsoft.AspNetCore.Mvc.Filters;

namespace cdf_api_integrador.Filters;

public class PermissionAttribute : ActionFilterAttribute
{
    public string Nivel { get;set; } = default!;
    public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
    {
        if( string.IsNullOrEmpty(filterContext.HttpContext.Request.Headers["Authorization"]) )
        {
            return;
        }

        var token = filterContext.HttpContext.Request.Headers["Authorization"].ToString();
        string json = string.Empty;
        
        try{
            json = Jose.JWT.Decode(token);
        }
        catch{
            return;
        }

        var userLogged = JsonSerializer.Deserialize<UserJwtDTO>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if(userLogged is null)
        {
            return;
        }

        var nivelArray = Nivel.Split(",");
        if(!nivelArray.Contains(userLogged.Regra))
        {
            filterContext.HttpContext.Response.StatusCode = 403;
            await filterContext.HttpContext.Response.WriteAsJsonAsync(new {
                Mensagem = "Usuário sem permissão para esta ação"
            });
            return;
        }

        await base.OnActionExecutionAsync(filterContext, next);
    }
}
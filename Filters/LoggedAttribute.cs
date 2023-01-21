using System.Text.Json;
using cdf_api_integrador.DTOs;
using Microsoft.AspNetCore.Mvc.Filters;

namespace cdf_api_integrador.Filters;

public class LoggedAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        if(string.IsNullOrEmpty(context.HttpContext.Request.Headers["Authorization"]))
        {
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsJsonAsync(new {
                Mensagem = "Token JWT obrigatório"
            });
            return;
        }

        var token = context.HttpContext.Request.Headers["Authorization"].ToString();
        string json = string.Empty;

        try
        {
            json = Jose.JWT.Decode(token);
        }
        catch 
        {
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsJsonAsync(new {
                Mensagem = "Token inválido"
            });
            return;
        }

        var userLogged = JsonSerializer.Deserialize<UserJwtDTO>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (userLogged is null)
        {
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsJsonAsync(new {
                Mensagem = "Token inválido"
            });
            return;   
        }
        
        if (userLogged.Expiracao < DateTime.Now)
        {
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsJsonAsync(new {
                Mensagem = "Token expirado"
            });
            return;   
        }

        await base.OnActionExecutionAsync(context, next);
    }
}
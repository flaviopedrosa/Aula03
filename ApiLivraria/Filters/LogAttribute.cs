using ApiLivraria.Services;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ApiLivraria.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userId = "anonimous";
            string uri = context.HttpContext.Request.Scheme + "://" + context.HttpContext.Request.Host + context.HttpContext.Request.Path + "("+ context.HttpContext.Request.Method + ")";
            LogService.Criar(uri, userId);
            base.OnActionExecuting(context);
        }
    }
}

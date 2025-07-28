using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.CustomActionFiltter
{
    public class ValidationModelAttribute:ActionFilterAttribute
    {


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            if(context.ModelState.IsValid==false)
            {
                context.Result= new BadRequestResult();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZWalks.API.CustomActionFilters
{
    public class ValidateModelAttribute: ActionFilterAttribute
    {
        // we are overriding this method because we are creating a custom method 
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}

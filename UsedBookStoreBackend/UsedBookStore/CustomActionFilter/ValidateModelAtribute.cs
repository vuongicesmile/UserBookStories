using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UsedBookStore.CustomActionFilter
{
    public class ValidateModelAtribute : ActionFilterAttribute
    {
        //overide actionExcuxing + Tabs (thứ 2)
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;

// namespace HFC.API.MiddleWares
// {
//     public class HandleErrorAttribute : ActionFilterAttribute
//     {
//         public override void OnActionExecuting(ActionExecutingContext filterContext)
//         {
//             base.OnActionExecuting(filterContext);

//             try
//             {
//                 filterContext.Result = filterContext.ActionDescriptor.ExecuteResult(filterContext.HttpContext);
//             }
//             catch (Exception ex)
//             {
//                 filterContext.Result = new BadRequestObjectResult("Failure");
//             }
//         }

//     }



// }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HFC.API.MiddleWares
{
    public class HandleErrorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            try
            {
                // Do nothing
            }
            catch (Exception ex)
            {
                filterContext.Result = new BadRequestObjectResult(ex.Message);
            }
        }

    }

}

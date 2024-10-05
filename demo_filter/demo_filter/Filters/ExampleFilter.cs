using Microsoft.AspNetCore.Mvc.Filters;

namespace demo_filter.Filters
{
    public class ExampleFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("executed: " + context.ActionDescriptor.DisplayName);
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("executing: " + context.ActionDescriptor.DisplayName);
        }
    }
}

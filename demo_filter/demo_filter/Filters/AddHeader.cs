﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace demo_filter.Filters
{
    public class AddHeader : ResultFilterAttribute
    {
        readonly string name;
        readonly string value;

        public AddHeader(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(name, new string[] {value});
            base.OnResultExecuting(context);
        }
    }
}

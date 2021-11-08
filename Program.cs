using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo_Filters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class CustomFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //To do : before the action executes  
            context.Result = new ContentResult()
            {
                Content = "Short circuit filter ";

            Console.WriteLine("Things to do before action execuites");

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //To do : after the action executes  
            Console.WriteLine("Things to do After action execuites");

        }


    }

}


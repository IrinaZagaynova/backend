using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Translator;

namespace Translator
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.Run(async (context) =>
            {
                Dictionary dictionary = new Dictionary("dictionary.txt");
                if (context.Request.Query.ContainsKey("word"))
                {
                    string word = context.Request.Query["word"];
                    string translation = dictionary.TranslateWord(word);
                    if (translation != "")
                    {
                        context.Response.ContentType = "text/plain; charset=utf-8";
                        await context.Response.WriteAsync(translation);
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            });
        }
    }
}

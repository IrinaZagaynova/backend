using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Translator
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {     
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }           

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    if (context.Request.Query.ContainsKey("word"))
                    {
                        string word = context.Request.Query["word"];
                        string translatedWord = "";
                        if (TranslateData.TranslateTheWord(word, ref translatedWord))
                        {
                            context.Response.ContentType = "text/plain; charset=utf-8";       
                            await context.Response.WriteAsync(translatedWord);
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
            });
        }
    }
}

using ExWebApiRestFull.Model.Context;
using ExWebApiRestFull.Model.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExWebApiRestFull
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //for xml
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ExWebApiRestFull.xml"), true);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExWebApiRestFull", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "ExWebApiRestFull", Version = "v2" });

                //foe version
                c.DocInclusionPredicate((doc, apiDescription) =>
                {
                    if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var version = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return version.Any(v => $"v{v.ToString()}" == doc);
                });
            });

            services.AddScoped<ToDoRepository, ToDoRepository>();
            services.AddScoped<CategoryRepository, CategoryRepository>();

            string ConnectionString = @"data source =.; initial catalog = ApiDb;  integrated security = true  ";
            services.AddEntityFrameworkSqlServer().AddDbContext<Context>(option => option.UseSqlServer(ConnectionString));
            services.AddApiVersioning(option => { option.AssumeDefaultVersionWhenUnspecified = true;
               
                //دیفالت ای پی ای هایی که قبل از تعریف شده اند 1 تعریف می کنیم
                option.DefaultApiVersion = new ApiVersion(1,0);

                //
                //برای اینکه یکسری اطلاعات در هدر درخواست در مورد ورژن نمایش داده شود
                option.ReportApiVersions = true;
                   } );       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //convert api to json file
                app.UseSwagger();


                //convert api to ui
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExWebApiRestFull v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "ExWebApiRestFull v2");

                }) ;
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

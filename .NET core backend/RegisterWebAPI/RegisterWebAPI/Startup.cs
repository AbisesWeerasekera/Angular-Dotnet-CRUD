using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RegisterWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterWebAPI
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
      //services.AddControllers();

      //Build a json serializer after installing the "microsoft.asp.netcore.mvc.newtonsoftjson" nuget package
      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      }).AddXmlDataContractSerializerFormatters();


      //use cors
      //to accept headers which come across localhost 4200 origin -->After installing microsoft.asp.net.core.cors package
      services.AddCors(options =>
      {
        options.AddPolicy("CoreApi", builder => builder.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod());
      });

      //create a new database service after adding the property(Users.cs class) to the RegisterDbContext class
      //Using registerDbContext class and connection string can create a database service
      services.AddDbContext<RegisterDBContext>(options =>
      options.UseSqlServer("Server=DESKTOP-8FJKHGN;Database=REGISTER;Trusted_Connection=True;"));
      
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
      //Add the created core in line number 32-45
      app.UseCors("CoreApi");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

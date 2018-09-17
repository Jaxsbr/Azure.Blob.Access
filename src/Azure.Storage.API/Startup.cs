using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MediatR;
using MediatR.Pipeline;
using Azure.Storage.Application.BlobContainers.Queries;
using System.Reflection;
using Azure.Storage.Persistence;

namespace Azure.BlobAccess.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddSingleton<IStorageAccount>(new StorageAccount(connectionString: Configuration.GetConnectionString("StorageAccountConnectionString")));
            //services.AddSingleton<IBlobContainerRepository, BlobContainerRepository>();
            //services.AddTransient<IBlobContainer, BlobContainer>();
            
            services.AddMediatR(typeof(GetAllBlobContainersQuery).GetTypeInfo().Assembly);              
      


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

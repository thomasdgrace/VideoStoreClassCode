using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoStoreNew.Services;
using VideoStoreNew.Data;
using Microsoft.EntityFrameworkCore;
using VideoStoreNew.Entities;
using Microsoft.AspNetCore.Identity;

namespace VideoStoreNew
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json"); //Add JSON with optional: true is for if the file is missing 
                //.AddJsonFile("appsettings.json", optional: true);
            if (env.IsDevelopment())
            {
                //If in development then we will use the user secerts file, as this does not get into source control
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Connection string that retireves the "Default Connection" from User secrets (COuld be set to get it from the appsettings.json as well)
            // Adding the Db Context that we made in the data folder to the project and configring the options in its contructor to use SQL server
            var conn = Configuration.GetConnectionString("DefaultConnection");            
            services.AddDbContext<VideoDbContext>(options => options.UseSqlServer(conn));
            //Add the Identity Services 
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<VideoDbContext>();
            //Add the MVC routing 
            services.AddMvc();
            //Add the JSON appsetting services to the project to use 
            services.AddSingleton(provider => Configuration );
            //COnfigure our own message service that can be used through dependancy injection 
            services.AddSingleton<IMessageService, ConfigurationMessageService>();

            //Using the IVideo interface and the Mock Video Data to simulate the database and have test data 
            services.AddScoped<IVideoData, SqlVideoData>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (context) =>
            {
                
            
            await context.Response.WriteAsync(msg.GetMessage());
            });
        }
    }
}

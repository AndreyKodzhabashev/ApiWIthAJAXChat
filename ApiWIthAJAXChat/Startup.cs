using Messages.Data;
using Messages.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiWIthAJAXChat
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var test = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MessagesDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Messages;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddCors(options =>
            options.AddPolicy("MessagesCORSPolicy", policy =>
            {
                //policy.WithOrigins("http://localhost:63342").AllowAnyHeader();
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                //policy.AllowAnyMethod();
            }
           ));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IMessagesService, MessagesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<MessagesDbContext>())
                {
                    context.Database.EnsureCreated();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("MessagesCORSPolicy");
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using AbstractNode.BLL.Infrastructure;
using AbstractNode.BLL.Interfaces;
using AbstractNode.BLL.Services;
using AbstractNode.DAL.Interfaces;
using AbstractNode.DAL.Repositories;
using AbstractNode.DAL.Infrastructure;

namespace AbstractNode.Web
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
            services.AddDbContext<AbstractNodeContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddSingleton(MapperProfile.Instance);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INodeService, NodeService>();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Account manager" });
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account manager V1");
            });

            app.UseMvc();
        }
    }
}

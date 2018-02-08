using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AbstractNode.BLL.Infrastructure;
using AbstractNode.BLL.Interfaces;
using AbstractNode.BLL.Services;
using AbstractNode.DAL.Interfaces;
using AbstractNode.DAL.Repositories;

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
            services.AddSingleton(Configuration.GetConnectionString("DBConnection"));
            services.AddSingleton(MapperProfile.Instance);
            services.AddSingleton<INodeService, NodeService>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

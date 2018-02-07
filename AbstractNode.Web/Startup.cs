using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using AbstractNode.BLL.Infrastructure;
using AbstractNode.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbstractNode.Web
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
            NinjectModule businessLogicModule = new BusinessLogicModule();
            NinjectModule serviceModule = new ServiceModule("Data Source=IF979\\SQLEXPRESS;Integrated Security=True;Database=AbstractNode");
            var kernel = new StandardKernel(businessLogicModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

using Jorge.Inventory.IRepositories;
using Jorge.Inventory.IServices;
using Jorge.Inventory.Repositories;
using Jorge.Inventory.Services;
using Jorge.Inventory.Services.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jorge.Inventory.Web.Services
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
            AutoMapperBootStrapper.ConfigureAutoMapper();

            services.AddApplicationInsightsTelemetry(Configuration);
            //services.AddDbContext<LoteryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
       

            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            //services.AddScoped<ContextDb>(s => new ContextDb(Configuration.GetConnectionString("defaultConnection")));
  
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

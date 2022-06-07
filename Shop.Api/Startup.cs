using Microsoft.OpenApi.Models;
using Shop.Domain.Handlers;
using Shop.Domain.Repositories;
using Shop.Infra.Data;
using Shop.Infra.Repositories;
using Shop.Shared;

namespace Shop.Api
{
    public class Startup
    {
        public IConfiguration? Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddResponseCompression();
            services.AddScoped<ShopDataContext, ShopDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ProductHandler, ProductHandler>();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Shop",
                    Description = "Virtual Shop",
                });
            });
            Settings.ConnectionString = $"{Configuration["ConnectionString"]}";
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop");
            });
        }
    }
}

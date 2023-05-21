using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaDelivery_V4.DAL;

namespace PizzaDelivery_V4
{
    public class Startup
    {
        public Startup(IConfiguration conf)
        {
            Configuration = conf;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=VNEDOSTUPA\\SQLEXXPRESS;Database=practic;Trusted_Connection=True;";
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(con));
            services.AddControllers();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IProductService, ProductService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza Delivery", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaDelivery v1.0"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
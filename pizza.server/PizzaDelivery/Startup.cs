using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery;   // пространство имен моделей
using Microsoft.EntityFrameworkCore; // пространство имен EntityFramework
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PizzaDelivery.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PizzaDelivery.Main;
using PizzaDelivery.Models;

namespace PizzaDelivery
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
            string con = "Server=VNEDOSTUPA\\SQLEXXPRESS;Database=practic;Trusted_Connection=True;";
            //Console.WriteLine(Routine.SECRET);
            //Console.WriteLine(Routine.ISSUER);
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(con));
            services.AddControllers();
            services.AddScoped<ProductService>();
            services.AddScoped<ClientService>();
            //services.AddScoped<JwtService>();
            //services.AddScoped<JwtMiddleware>();


            //services.AddSingleton();
            var authOptions = Configuration.GetSection("jwt").Get<AuthOptions>();
           // services.AddSingleton(x => new JwtService(jwtTokenConfig.Secret, jwtTokenConfig.Issuer));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaDelivery", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                //options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaDelivery v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

           app.UseCors();


            //app.UseMiddleware<JwtMiddleware>();


            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
/*
            app.MapWhen(context => !context.Request.Path.StartsWithSegments("/api/products") || !context.Request.Path.StartsWithSegments("/api/auth"), 
                builder =>
            {
                builder.UseMiddleware<JwtMiddleware>();
            });*/
        }
    }
}

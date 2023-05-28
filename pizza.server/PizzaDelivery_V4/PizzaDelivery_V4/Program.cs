using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaDelivery_V4;
using PizzaDelivery_V4.DAL2.Repositories.EntitiesRepository;
using PizzaDelivery_V4.DAL2.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddControllers();
builder.Services.AddDbContext<PDDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("MvcPizzaConnectionString")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductPropertiesRepository, ProductPropertiesRepository>();
builder.Services.AddScoped<IProductOptionsRepository, ProductOptionsRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(page =>
{
    page.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    page.SwaggerDoc("client", new OpenApiInfo { Title = "client", Version = "v1" });
    page.SwaggerDoc("employee", new OpenApiInfo { Title = "delivery", Version = "v1" });
    page.SwaggerDoc("post", new OpenApiInfo { Title = "employee", Version = "v1" });
    page.SwaggerDoc("product", new OpenApiInfo { Title = "order", Version = "v1" });
    page.SwaggerDoc("service", new OpenApiInfo { Title = "orderItems", Version = "v1" });
    page.SwaggerDoc("sklad", new OpenApiInfo { Title = "product", Version = "v1" });
    page.SwaggerDoc("storeAddress", new OpenApiInfo { Title = "productOptions", Version = "v1" });
    page.SwaggerDoc("zakaz", new OpenApiInfo { Title = "productProperties", Version = "v1" });
});



var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(page =>
    {
        page.SwaggerEndpoint("/swagger/client/swagger.json", "client");
        page.SwaggerEndpoint("/swagger/delivery/swagger.json", "delivery");
        page.SwaggerEndpoint("/swagger/employee/swagger.json", "employee");
        page.SwaggerEndpoint("/swagger/order/swagger.json", "order");
        page.SwaggerEndpoint("/swagger/orderItems/swagger.json", "orderItems");
        page.SwaggerEndpoint("/swagger/product/swagger.json", "product");
        page.SwaggerEndpoint("/swagger/productOptions/swagger.json", "productOptions");
        page.SwaggerEndpoint("/swagger/productProperties/swagger.json", "productProperties");
        page.RoutePrefix = string.Empty;
    });

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

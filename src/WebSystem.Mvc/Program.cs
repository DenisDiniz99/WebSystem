using Microsoft.EntityFrameworkCore;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Notifications;
using WebSystem.Mvc.Infrastructure.Data;
using WebSystem.Mvc.Infrastructure.Data.Repositories;
using WebSystem.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettigns.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();


// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                                            options.UseSqlServer(connectionString));


//Dependency Injection
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddScoped<IHandleNotification, HandleNotification>();

builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error/500");
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

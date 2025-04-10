using Microsoft.EntityFrameworkCore;
using StockTrack.Data.Data;
using StockTrack.Data.Repositories;
using StockTrack.Data.Repositories.Interfaces;
using StockTrack.Mapping;
using StockTrack.Services.Mapping;
using StockTrack.Services.services;
using StockTrack.Services.services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockTrackConnectionString")
    ));

//Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IUserService, UserService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(ViewModelMappingProfile));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

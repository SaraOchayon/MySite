using LoginRegister.Controllers;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserRepositories, UserRepositories>();
builder.Services.AddTransient<IUserSevices, UserSevices>();

builder.Services.AddTransient<IProductRepositories, ProductRepositories>();
builder.Services.AddTransient<IProductServices, ProductServices>();

builder.Services.AddTransient<IOrderRepositories, OrderRepositories>();
builder.Services.AddTransient<IOrderServices, OrderServices>();

builder.Services.AddTransient<ICategoryRepositories, CategoryRepositories>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<StshopContext>(option => option.UseSqlServer
("Server=srv2\\pupils;Database=STshop;Trusted_Connection=True;TrustServerCertificate=True"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.Run();

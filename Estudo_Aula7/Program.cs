using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Estudo_Aula7.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Estudo_Aula7Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Estudo_Aula7Context") ?? throw new InvalidOperationException("Connection string 'Estudo_Aula7Context' not found.")));


builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.Name = ".Estudo_Aula7.Session";
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.Name = ".AspNetCore.Session";
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

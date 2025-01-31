using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Estudo_Exemplo1.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Estudo_Exemplo1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Estudo_Exemplo1Context") ?? throw new InvalidOperationException("Connection string 'Estudo_Exemplo1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(5);
    option.Cookie.Name = ".Sessão";
});

builder.Services.AddResponseCaching(option =>
{
    option.SizeLimit = 200;
    option.MaximumBodySize = 20;
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

app.UseSession();

app.UseRouting();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

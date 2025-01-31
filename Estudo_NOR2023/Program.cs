using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Estudo_NOR2023.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Estudo_NOR2023Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Estudo_NOR2023Context") ?? throw new InvalidOperationException("Connection string 'Estudo_NOR2023Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Proprietarios}/{action=Index}/{id?}");

app.Run();

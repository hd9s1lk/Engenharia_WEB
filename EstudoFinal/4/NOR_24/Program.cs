using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NOR_24.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NOR_24Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NOR_24Context") ?? throw new InvalidOperationException("Connection string 'NOR_24Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

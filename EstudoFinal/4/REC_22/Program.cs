using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using REC_22.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<REC_22Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("REC_22Context") ?? throw new InvalidOperationException("Connection string 'REC_22Context' not found.")));

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
    name: "PaisesAlias",
    pattern: "Paises/",
    defaults: new { controller = "Home", action = "Index" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

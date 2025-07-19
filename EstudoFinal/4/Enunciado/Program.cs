using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Enunciado.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EnunciadoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EnunciadoContext") ?? throw new InvalidOperationException("Connection string 'EnunciadoContext' not found.")));

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
    name: "RootAlias",
    pattern: "/",
    defaults: new { controller = "Estudantes", action = "Listar" }
);



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

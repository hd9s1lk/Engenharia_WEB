using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DB_al78804>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB_al78804") ?? throw new InvalidOperationException("Connection string 'DB_al78804' not found.")));

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
    name: "AmigosAlias",
    pattern: "Amigos/",
    defaults: new { controller = "Contactos", action = "Lista" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contactos}/{action=Lista}/{id?}");

app.Run();

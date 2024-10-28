using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Aula_7_Login.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Aula_7_LoginContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Aula_7_LoginContext") ?? throw new InvalidOperationException("Connection string 'Aula_7_LoginContext' not found.")));


builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.Name = ".Aula07";
});
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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

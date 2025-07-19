using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using REC_23.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<REC_23Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("REC_23Context") ?? throw new InvalidOperationException("Connection string 'REC_23Context' not found.")));

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
    pattern: "{controller=Avaliacao}/{action=Pauta}/{id?}");

app.Run();

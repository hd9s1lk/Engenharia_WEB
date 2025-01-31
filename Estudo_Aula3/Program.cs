﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Estudo_Aula3.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Estudo_Aula3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Estudo_Aula3Context") ?? throw new InvalidOperationException("Connection string 'Estudo_Aula3Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<DBInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var initializer = services.GetRequiredService<DBInitializer>();
initializer.Run();



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

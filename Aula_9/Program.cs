using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.CacheProfiles.Add("TestCacheProfile",
        new Microsoft.AspNetCore.Mvc.CacheProfile()
        {
            Duration = 20,
            Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any,
            VaryByHeader = "User-Agent"
        });
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
app.UseStaticFiles( new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public, max-age=" + 20;
        ctx.Context.Response.Headers[HeaderNames.LastModified] = ctx.File.LastModified.ToString();
    }
});

app.UseResponseCaching();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

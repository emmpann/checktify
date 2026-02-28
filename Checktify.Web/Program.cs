using Checktify.Repository.Extensions;
using Checktify.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.LoadRepositoryExtenstions(builder.Configuration);
builder.Services.LoadServiceExtensions(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

#pragma warning disable ASP0014
app.UseEndpoints(endpoint =>
{
     //Route root URL to Admin area dashboard
    endpoint.MapControllerRoute(
        name: "root",
        pattern: "",
        defaults: new { area = "Admin", controller = "Dashboard", action = "Index" }
    );

    endpoint.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

    endpoint.MapAreaControllerRoute(
        name: "User",
        areaName: "User",
        pattern: "User/{controller=Dashboard}/{action=Index}/{id?}");

    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    });

app.Run();

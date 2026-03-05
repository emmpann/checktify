using Checktify.Repository.Extensions;
using Checktify.Service.Extensions;
using NToastNotify;
using Checktify.Entity.Identity.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions
{
    ProgressBar = false,
    PositionClass = ToastPositions.BottomCenter,
    PreventDuplicates = true,
    //CloseButton = true
});

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

// Seed identity data at startup (roles and default users)
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
//        var userManager = services.GetRequiredService<UserManager<AppUser>>();

//        // Fixed ids (match those used in configuration/migrations)
//        var adminRoleId = "16ED196E-D750-418B-886C-35F214BC7C59";
//        var userRoleId = "1CF42ED7-6CE9-43CE-A36C-97B03FAE641D";

//        // Ensure roles
//        if (!await roleManager.RoleExistsAsync("Admin"))
//        {
//            var adminRole = new AppRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "11111111-1111-1111-1111-111111111111" };
//            await roleManager.CreateAsync(adminRole);
//        }

//        if (!await roleManager.RoleExistsAsync("User"))
//        {
//            var userRole = new AppRole { Id = userRoleId, Name = "User", NormalizedName = "USER", ConcurrencyStamp = "22222222-2222-2222-2222-222222222222" };
//            await roleManager.CreateAsync(userRole);
//        }

//        // Ensure default admin user
//        var adminUserName = "admin";
//        var adminEmail = "efant@gmail.com";
//        var adminId = "BA796781-DD1E-4D24-B4B7-BFA191EA658A";
//        var admin = await userManager.FindByNameAsync(adminUserName);
//        if (admin == null)
//        {
//            admin = new AppUser { Id = adminId, UserName = adminUserName, Email = adminEmail, NormalizedUserName = adminUserName.ToUpper(), NormalizedEmail = adminEmail.ToUpper(), EmailConfirmed = true };
//            var createAdmin = await userManager.CreateAsync(admin, "Admin123@");
//            if (createAdmin.Succeeded)
//            {
//                await userManager.AddToRoleAsync(admin, "Admin");
//            }
//            else
//            {
//                Console.WriteLine("Failed to create admin user: " + string.Join(',', createAdmin.Errors.Select(e => e.Description)));
//            }
//        }

//        // Ensure default normal user
//        var normalUserName = "user";
//        var normalEmail = "efant2@gmail.com";
//        var normalId = "CD06B166-2379-4BC0-9FD1-3E9F50C6C4B2";
//        var normal = await userManager.FindByNameAsync(normalUserName);
//        if (normal == null)
//        {
//            normal = new AppUser { Id = normalId, UserName = normalUserName, Email = normalEmail, NormalizedUserName = normalUserName.ToUpper(), NormalizedEmail = normalEmail.ToUpper(), EmailConfirmed = true };
//            var createUser = await userManager.CreateAsync(normal, "User123@");
//            if (createUser.Succeeded)
//            {
//                await userManager.AddToRoleAsync(normal, "User");
//            }
//            else
//            {
//                Console.WriteLine("Failed to create default user: " + string.Join(',', createUser.Errors.Select(e => e.Description)));
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        // If seeding fails, write to console. In production use a logger.
//        Console.WriteLine("An error occurred while seeding the database: " + ex.Message);
//    }
//}

app.Run();

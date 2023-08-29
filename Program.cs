

using Escuela_Sor_Maria.Data;
using Escuela_Sor_Maria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Define el tiempo de expiracion deseado
    options.SlidingExpiration = true; // Hace que la sesion se extienda con cada solicitud mientras esta activa
});





builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Crear roles si no existen
        if (!await roleManager.RoleExistsAsync("SuperUsuario"))
        {
            await roleManager.CreateAsync(new IdentityRole("SuperUsuario"));
        }
        if (!await roleManager.RoleExistsAsync("Visitante"))
        {
            await roleManager.CreateAsync(new IdentityRole("Visitante"));
        }

        // Verificar si no hay usuarios registrados
        if (!context.Users.Any())
        {
            var user = new IdentityUser { UserName = "superusuario@gmail.com", Email = "000000000", EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, "SuperUsuario1@");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "SuperUsuario");
            }
        }
    }
    catch (Exception ex)
    {
        // Manejodeerrores
    }
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa");
app.MapRazorPages();

app.Run();

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAppPharmacy.Data;
using WebAppPharmacy.Models;
using WebAppPharmacy.Repositories.RepoCategories;
using WebAppPharmacy.Repositories.RepoProduct;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<WebAppPharmacyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie();
builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();
builder.Services.AddAutoMapper(typeof(Program));
// Mendaftarkan semua repository secara dinamis
var repositoryAssembly = Assembly.GetExecutingAssembly();

// Mendaftarkan semua tipe yang di-implementasi oleh IRepository
var repositoryTypes = repositoryAssembly.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.Name == "I" + t.Name));


foreach (var repoType in repositoryTypes)
{
    // Mendaftar semua repository dan implementasinya ke DI container
    foreach (var interfaceType in repoType.GetInterfaces())
    {
        builder.Services.AddScoped(interfaceType, repoType);
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "Super Admin", "User", "Manager", "Customer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Dashboard",
    areaName: "Dashboard",
    pattern: "Dashboard/{controller=Dashboard}/{action=index}"
);

app.MapAreaControllerRoute(
    name: "Account",
    areaName: "Account",
    pattern: "{controller=Account}/{action=Login}"
);

app.MapAreaControllerRoute(
    name: "Categories",
    areaName: "Categories",
    pattern: "Categories/{controller=Categories}/{action=Index}/{id?}"
);

app.MapAreaControllerRoute(
    name: "Products",
    areaName: "Products",
    pattern: "Product/{controller=Product}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();

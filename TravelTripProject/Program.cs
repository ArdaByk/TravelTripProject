using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TravelTripProject.Models.Siniflar;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ContextDbContext");

// Register EF Core DbContext with a connection string
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/GirisYap/Login";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Serve wwwroot (default)
app.UseStaticFiles();

// Also serve the project-root "web2" folder at the "/web2" request path so links like "/web2/css/..." work
var web2Folder = Path.Combine(Directory.GetCurrentDirectory(), "web2");
if (Directory.Exists(web2Folder))
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(web2Folder),
        RequestPath = "/web2"
    });
}

var webloginFolder = Path.Combine(Directory.GetCurrentDirectory(), "weblogin");
if (Directory.Exists(webloginFolder))
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(webloginFolder),
        RequestPath = "/weblogin"
    });
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();

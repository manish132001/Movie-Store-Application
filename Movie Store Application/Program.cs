using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Movie_Store_Application.Models.Domain;
using Movie_Store_Application.Repositories.Abstraction;
using Movie_Store_Application.Repositories.Implementation;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserAuthenticationServices, UserAuthenticationServices>();
builder.Services.AddScoped<IGenreServices, GenreServices>();
builder.Services.AddScoped<IMovieServices, MovieServices>();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

//for Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<DatabaseContext>().
    AddDefaultTokenProviders();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); // Set the session timeout to 10 minutes
    options.Cookie.HttpOnly = true;                 // Make the cookie HttpOnly
    options.Cookie.IsEssential = true;              // Make the cookie essential
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/UserAuthentication/Login";   // Login page URL
    options.AccessDeniedPath = "/UserAuthentication/Logout"; // Access denied URL

    // Set cookie expiration to 10 minutes
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);

    // Sliding expiration will extend the cookie on each request (optional)
    options.SlidingExpiration = true;

    // Automatically logout the user after 10 minutes of inactivity
    options.Events.OnRedirectToLogin = context =>
    {
        context.HttpContext.Session.Clear(); 
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
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
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();

using Blog.Data;
using Blog.Data.Enum;
using Blog.IRepositories;
using Blog.Models;
using Blog.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        AddServicesToTheContainer(builder);
        AddDbContextService(builder);           //  DB Context service
        AddRepositories(builder);               //  Adding Repositories
        AddIdentityAndAuthentication(builder);  //  Adding Identity Services to make Migration with User identity

        var app = builder.Build();

        // Seed data if args contain "seeddata"
        if (args.Count() == 1 && args[0].ToLower().Equals("seeddata"))
        {
            DataSeeder.SeedDataToDB(app);
        }

        // Configure the HTTP request pipeline.
        ConfigureHTTPRequest(app);

        app.Run();
    }

    private static void AddServicesToTheContainer(WebApplicationBuilder builder)
    {
        builder.Services.AddControllersWithViews();
    }

    private static void AddDbContextService(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }

    private static void AddIdentityAndAuthentication(WebApplicationBuilder builder)
    {
        // Add Identity Service to use migration and User Entoityt in the DB
        builder.Services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();

        // Add Cookies Service to make the App remember logged person
        builder.Services.AddMemoryCache();
        builder.Services.AddSession();
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie();
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
    }

    private static void ConfigureHTTPRequest(WebApplication app)
    {
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
    }
}
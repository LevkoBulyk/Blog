using Blog.Data;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        AddServicesToTheContainer(builder);
        AddDbContextService(builder); // DB Context service

        var app = builder.Build();

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
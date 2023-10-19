using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _28_NguyenQuangVinh_ShopPizza.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace _28_NguyenQuangVinh_ShopPizza
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DBContext_28_NguyenQuangVinh>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext_28_NguyenQuangVinh") ?? throw new InvalidOperationException("Connection string 'DBContext_28_NguyenQuangVinh' not found.")));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            options.SlidingExpiration = true;
            options.AccessDeniedPath = "/Forbidden";
            options.LogoutPath = "/Logout";
            options.LoginPath = "/Login";
             });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "0"));
                options.AddPolicy("Staff", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
            });
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
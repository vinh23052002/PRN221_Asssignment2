using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _28_NguyenQuangVinh_ShopPizza.Data;
namespace _28_NguyenQuangVinh_ShopPizza
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DBContext_28_NguyenQuangVinh>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext_28_NguyenQuangVinh") ?? throw new InvalidOperationException("Connection string 'DBContext_28_NguyenQuangVinh' not found.")));

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

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
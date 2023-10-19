using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _28_NguyenQuangVinh_ShopPizza.Models;

namespace _28_NguyenQuangVinh_ShopPizza.Data
{
    public class DBContext_28_NguyenQuangVinh : DbContext
    {
        public DBContext_28_NguyenQuangVinh (DbContextOptions<DBContext_28_NguyenQuangVinh> options)
            : base(options)
        {
        }


        public DbSet<_28_NguyenQuangVinh_ShopPizza.Models.Customer> Customer { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
        }

        public DbSet<_28_NguyenQuangVinh_ShopPizza.Models.Order>? Order { get; set; }

        public DbSet<_28_NguyenQuangVinh_ShopPizza.Models.Product>? Product { get; set; }
    }
}

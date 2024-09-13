using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuProduct>()
                .HasKey(mp => new { mp.MenuId, mp.ProductId });

            modelBuilder.Entity<MenuProduct>()
                .ToTable("Product_Menu");

            // Other configurations...
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreAddress> StoreAddresses { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Menu> Menus {  get; set; }
        public DbSet<MenuProduct> MenuProducts { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}

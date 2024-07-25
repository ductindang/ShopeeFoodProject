using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Store)
            //    .WithMany()
            //    .HasForeignKey(p => p.StoreId);

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Discount)
            //    .WithMany()
            //    .HasForeignKey(p => p.DiscountId);
            

        }

        public void SeedData()
        {
            Random rand = new Random();

            // Seed Categories
            if (!Categories.Any())
            {
                for (int i = 1; i <= 6; i++)
                {
                    Categories.Add(
                        new Category
                        {
                            Name = $"Category {i}",
                            CreatedAt = DateTime.Now.AddDays(-rand.Next(0, 30)),
                            UpdatedAt = DateTime.Now.AddDays(-rand.Next(0, 30))
                        }
                    );
                }
                SaveChanges();
            }

            // Seed SubCategories
            if (!SubCategories.Any())
            {
                for (int i = 1; i <= 15; i++)
                {
                    SubCategories.Add(
                        new SubCategory
                        {
                            Name = $"SubCategory {i}"
                        }
                    );
                }
                SaveChanges();
            }

            // Seed Users
            if (!Users.Any())
            {
                for (int i = 1; i <= 15; i++)
                {
                    Users.Add(
                        new User
                        {
                            FullName = $"User {i}",
                            Gender = (byte)rand.Next(0, 2),
                            PhoneNumber = $"123{i}6415{i}",
                            Email = $"user{i}{i}{i}@Example.com",
                            Password = $"{i}{i}{i}",
                            Avatar = $"Avatar for User {i}",
                            CreatedAt = DateTime.Now.AddDays(-rand.Next(0, 30)),
                            UpdatedAt = DateTime.Now.AddDays(-rand.Next(0, 30)),
                        }
                    );
                }
                SaveChanges();
            }

            // Seed Stores
            if (!Stores.Any())
            {
                for (int i = 1; i <= 15; i++)
                {
                    Stores.Add(
                        new Store
                        {
                            Name = $"Store {i}",
                            Image = $"Image for Store {i}",
                            OptenTime = new TimeOnly(rand.Next(7, 11), 0),
                            CloseTime = new TimeOnly(rand.Next(17, 22), 0),
                            Description = $"Description for Store {i}"
                        }
                    );
                }
                SaveChanges();
            }

            // Seed Discounts
            if (!Discounts.Any())
            {
                for (int i = 1; i <= 15; i++)
                {
                    Discounts.Add(
                        new Discount
                        {
                            Name = $"Discount {i}",
                            Percentage = rand.Next(1, 51),
                            StartDate = DateTime.Now.AddDays(-rand.Next(1, 10)),
                            EndDate = DateTime.Now.AddDays(rand.Next(10, 30)),
                            Description = $"Description for Discount {i}"
                        }
                    );
                }
                SaveChanges();
            }

            // Seed Products
            if (!Products.Any())
            {
                for (int i = 1; i <= 15; i++)
                {
                    Products.Add(
                        new Product
                        {
                            CategoryId = rand.Next(1, 7),
                            SubCategoryId = rand.Next(1, 16),
                            StoreId = rand.Next(1, 16),  // Ensure StoreId is within range of seeded Stores
                            DiscountId = rand.Next(1, 15),  // Ensure DiscountId is within range of seeded Discounts
                            Name = $"Product {i}",
                            Price = rand.Next(10, 1000) + rand.NextDouble(),
                            Image = $"Image for product {i}",
                            Description = $"Description for Product {i}",
                            CreatedAt = DateTime.Now.AddDays(-rand.Next(0, 30)),
                            UpdatedAt = DateTime.Now.AddDays(-rand.Next(0, 30))
                        }
                    );
                }
                SaveChanges();
            }
        }



    }
}

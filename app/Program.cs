using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using PBO_GUI;

namespace App
{
    internal class Program
    {
        // Program Utama
        static void Main(string[] args)
        {
            // Configure the EF Core options
            // var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\SOSKOD\\kuliah\\pbo\\ta-pbo\\pbo-ta-bioskop\\db\\MyAppDb.mdf;Integrated Security=True;Connect Timeout=30;");

            // Inisialisasi database
            // 1. login dulu
            //      kalo gagal, return null
            //      kalo berhasil, lanjut
            // kalo gagal login / register -> return

            // program utama
            // using (var dbContext = new AppDbContext(optionsBuilder.Options))
            //{
            // Ensure database is created (for demo purposes)
            //  dbContext.Database.EnsureCreated();

            // Seed data (optional, if database is empty)
            //if (!dbContext.Products.Any())
            //{
            //dbContext.Products.Add(new Product { Id = 123, Name = "Sample Product", Price = 99.99M });
            //  dbContext.SaveChanges();
            //                }

            //              Console.WriteLine("Database setup complete. Ready to use!");

            // Main program logic

            // }
            while (true)
            {
                if (!TerminalDisplay.Display())
                    break;
            }
            Console.WriteLine("\nSampai Jumpa!");
        }
    }

    // EF Core DbContext
    // public class AppDbContext : DbContext{
    //     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    //     public DbSet<Product> Products { get; set; }
    // }

    // // EF Core Entity (Model)
    // public class Product
    // {
    //     public int Id { get; set; }
    //     public string Name { get; set; }
    //     public decimal Price { get; set; }
    // }
}

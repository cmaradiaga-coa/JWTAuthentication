using Microsoft.EntityFrameworkCore;
using WebApiDemo.Handlers;
using WebApiDemo.Models.Entities;

namespace WebApiDemo.Data;

public class AppDbContext : DbContext
{
    private string clave = PasswordHashHandler.HashPassword("admin123");
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<UserAccount> UserAccounts { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);

    //     _ = modelBuilder.Entity<UserAccount>().HasData([
    //             new UserAccount
    //             {
    //                 Id = 1,
    //                 FullName = "Administrator",
    //                 UserName = "admin",
    //                 Password =  clave // PasswordHashHandler.HashPassword("admin123")
    //             }
    //         ]);
    // }
}

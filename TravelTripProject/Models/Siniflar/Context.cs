using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TravelTripProject.Models.Siniflar;

public class Context : DbContext
{
    public Context()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-0TQ8MRR\\SQLEXPRESS;Database=TravelDb;Trusted_Connection=True;TrustServerCertificate=True");
    }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Adres> Adres { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Hakkimizda> Hakkimizda { get; set; }
    public DbSet<Iletisim> Iletisims { get; set; }
    public DbSet<Yorumlar> Yorumlars { get; set; }
}

using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
      
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      base.OnConfiguring(options);
      options.UseSqlServer("Server=Oğuzhan\\SQLEXPRESS; User Id=sa; Password=1234; Database=DbMiniOrderSystem; TrustServerCertificate=true;");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}

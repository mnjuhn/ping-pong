using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PingPong.Models

{
  public class PingPongContext : DbContext
  {
    public PingPongContext() : base()//"PingPongContext"
    {
    }
    public PingPongContext(DbContextOptions opts) : base(opts)//"PingPongContext"
    {
    }

    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
      {
        //entityType.SetTableName(entityType.DisplayName());

      }
      modelBuilder.Entity<Player>().HasData(new Player
      {
        id = 1,
        FirstName = "Uncle",
        LastName = "Bob"

      }, new Player
      {
        id = 2,
        FirstName = "Jan",
        LastName = "Kirsten"
      });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source=Ben-Desktop\\SQLEXPRESS;Initial Catalog=pingpong;Integrated Security=True;");
      base.OnConfiguring(optionsBuilder);
    }
  }
}

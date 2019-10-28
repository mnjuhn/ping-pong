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
        Id = 1,
        FirstName = "Uncle",
        LastName = "Bob",
        Age = 50,
        SkillLevel = Player.Level.Expert,
        email = "bob@gmail.com"
      }, new Player
      {
        Id = 2,
        FirstName = "Jan",
        LastName = "Kirsten",
        Age = 40,
        SkillLevel = Player.Level.Advanced,
        email = "jan@gmail.com",
      }, new Player
      {
        Id = 3,
        FirstName = "Lil",
        LastName = "Jen",
        Age = 30,
        SkillLevel = Player.Level.Beginner,
        email = "jen@gmail.com",
      }, new Player
      {
        Id = 4,
        FirstName = "Big",
        LastName = "Ben",
        Age = 45,
        SkillLevel = Player.Level.Intermediate,
        email = "jan@gmail.com",
      });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source=Ben-Desktop\\SQLEXPRESS;Initial Catalog=pingpong;Integrated Security=True;");
      base.OnConfiguring(optionsBuilder);
    }
  }
}

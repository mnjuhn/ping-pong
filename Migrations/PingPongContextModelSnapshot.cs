﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PingPong.Models;

namespace PingPong.Migrations
{
    [DbContext(typeof(PingPongContext))]
    partial class PingPongContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PingPong.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = (short)50,
                            FirstName = "Uncle",
                            LastName = "Bob",
                            SkillLevel = 3,
                            email = "bob@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            Age = (short)40,
                            FirstName = "Jan",
                            LastName = "Kirsten",
                            SkillLevel = 2,
                            email = "jan@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            Age = (short)30,
                            FirstName = "Lil",
                            LastName = "Jen",
                            SkillLevel = 0,
                            email = "jen@gmail.com"
                        },
                        new
                        {
                            Id = 4,
                            Age = (short)45,
                            FirstName = "Big",
                            LastName = "Ben",
                            SkillLevel = 1,
                            email = "jan@gmail.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

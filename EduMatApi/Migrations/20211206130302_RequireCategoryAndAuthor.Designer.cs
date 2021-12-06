﻿// <auto-generated />
using System;
using EduMatApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduMatApi.Migrations
{
    [DbContext(typeof(EduMatApiDbContext))]
    [Migration("20211206130302_RequireCategoryAndAuthor")]
    partial class RequireCategoryAndAuthor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EduMatApi.Models.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "I'm sharing knowledge!",
                            Name = "Zuzanna"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Collector of tutorials",
                            Name = "Wilhelm"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Quality over quantity",
                            Name = "Ursula"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The more I read the more I know",
                            Name = "Titus"
                        });
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("MaterialTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MaterialTypeId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "In this full course, we show you how to build a full REST API using .NET Core 3.1",
                            Location = "https://www.youtube.com/watch?v=fmvcAzHpsk8",
                            MaterialTypeId = 1,
                            PublishDate = new DateTime(2021, 11, 6, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3064),
                            Title = ".NET Core 3.1 MVC REST API - Full Course"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Description = " In this video, I am going to walk you through how MVC is set up, how authentication works, and how it is different from the .NET Framework version of MVC.",
                            Location = "https://www.youtube.com/watch?v=1ck9LIBxO14",
                            MaterialTypeId = 1,
                            PublishDate = new DateTime(2021, 11, 5, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3091),
                            Title = "Introduction to ASP.NET Core MVC in C# plus LOTS of Tips"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Description = "Step by step asp.net core fundamentals course to help you build asp.net core mvc web applications from scratch following the asp.net core best practices and conventions.",
                            Location = "https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU",
                            MaterialTypeId = 1,
                            PublishDate = new DateTime(2021, 11, 4, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3093),
                            Title = "ASP.NET core tutorial for beginners"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Description = "In this step by step tutorial, I show you how to secure a .NET Core API with JWT Bearer Authentication",
                            Location = "https://www.youtube.com/watch?v=3PyUjOmuFic",
                            MaterialTypeId = 1,
                            PublishDate = new DateTime(2021, 11, 3, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3096),
                            Title = "Secure a .NET Core API with Bearer Authentication"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 1,
                            Description = "Linus Torvalds visits Google to share his thoughts on git, the source control management system he created two years ago.",
                            Location = "https://www.youtube.com/watch?v=4XpnKHJAok8",
                            MaterialTypeId = 2,
                            PublishDate = new DateTime(2021, 11, 2, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3098),
                            Title = "Tech Talk: Linus Torvalds on git"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            Description = "Identity API tutorial",
                            Location = "https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/",
                            MaterialTypeId = 3,
                            PublishDate = new DateTime(2021, 11, 1, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3099),
                            Title = "ASP.NET Core Identity Tutorial"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            Description = "Learn .NET Basics in 3 Days",
                            Location = "https://www.guru99.com/asp-net-tutorial.html",
                            MaterialTypeId = 3,
                            PublishDate = new DateTime(2021, 10, 31, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3101),
                            Title = "ASP.NET Tutorial for Beginners"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 4,
                            Description = "Basic HTTP tutorial",
                            Location = "https://www.tutorialspoint.com/http/index.htm",
                            MaterialTypeId = 3,
                            PublishDate = new DateTime(2021, 10, 30, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3103),
                            Title = "HTTP Tutorial"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 1,
                            Description = "Controller action return types in ASP.NET Core web API",
                            Location = "https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0",
                            MaterialTypeId = 4,
                            PublishDate = new DateTime(2021, 10, 29, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3105),
                            Title = "Controller action return types"
                        },
                        new
                        {
                            Id = 10,
                            AuthorId = 2,
                            Description = "HTTP specs",
                            Location = "https://httpwg.org/specs/",
                            MaterialTypeId = 4,
                            PublishDate = new DateTime(2021, 10, 28, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3107),
                            Title = "HTTP Documentation"
                        },
                        new
                        {
                            Id = 11,
                            AuthorId = 1,
                            Description = "An interactive way to learn GIT branching",
                            Location = "https://learngitbranching.js.org/",
                            MaterialTypeId = 5,
                            PublishDate = new DateTime(2021, 10, 27, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3109),
                            Title = "Git branching"
                        },
                        new
                        {
                            Id = 12,
                            AuthorId = 4,
                            Description = "We'll be writing an api together next friday!",
                            Location = "out school",
                            MaterialTypeId = 5,
                            PublishDate = new DateTime(2021, 10, 26, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3111),
                            Title = "Interactive learning"
                        });
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Definition = "A tutorial in video form",
                            Name = "Video tutorial"
                        },
                        new
                        {
                            Id = 2,
                            Definition = "A video presentation",
                            Name = "Presentation"
                        },
                        new
                        {
                            Id = 3,
                            Definition = "A tutorial in text form",
                            Name = "Text tutorial"
                        },
                        new
                        {
                            Id = 4,
                            Definition = "Official documentation",
                            Name = "Documentation"
                        },
                        new
                        {
                            Id = 5,
                            Definition = "A learning resource you can learn from by interacting",
                            Name = "Interactive"
                        });
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Opinion")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaterialId = 1,
                            Opinion = "Just watch it.",
                            Score = 10
                        },
                        new
                        {
                            Id = 2,
                            MaterialId = 1,
                            Opinion = "Very good tutorial",
                            Score = 9
                        },
                        new
                        {
                            Id = 3,
                            MaterialId = 2,
                            Opinion = "A lot of useful stuff in this one",
                            Score = 8
                        },
                        new
                        {
                            Id = 4,
                            MaterialId = 4,
                            Opinion = "Get secured or get hacked!",
                            Score = 7
                        },
                        new
                        {
                            Id = 5,
                            MaterialId = 5,
                            Opinion = "Good to watch",
                            Score = 8
                        },
                        new
                        {
                            Id = 6,
                            MaterialId = 5,
                            Opinion = "Seems rude",
                            Score = 3
                        },
                        new
                        {
                            Id = 7,
                            MaterialId = 5,
                            Opinion = "What a guy!",
                            Score = 10
                        },
                        new
                        {
                            Id = 8,
                            MaterialId = 6,
                            Opinion = "I wouldn't know what to do without this guy",
                            Score = 10
                        },
                        new
                        {
                            Id = 9,
                            MaterialId = 7,
                            Opinion = "Good stuff",
                            Score = 9
                        },
                        new
                        {
                            Id = 10,
                            MaterialId = 7,
                            Opinion = "A bit too slow for me",
                            Score = 6
                        },
                        new
                        {
                            Id = 11,
                            MaterialId = 8,
                            Opinion = "A gentle introduction",
                            Score = 8
                        },
                        new
                        {
                            Id = 12,
                            MaterialId = 10,
                            Opinion = "Who has time for that?!",
                            Score = 3
                        },
                        new
                        {
                            Id = 13,
                            MaterialId = 11,
                            Opinion = "Decent",
                            Score = 6
                        },
                        new
                        {
                            Id = 14,
                            MaterialId = 12,
                            Opinion = "It was great, I learned so much!",
                            Score = 9
                        },
                        new
                        {
                            Id = 15,
                            MaterialId = 12,
                            Opinion = "Cool",
                            Score = 10
                        },
                        new
                        {
                            Id = 16,
                            MaterialId = 12,
                            Opinion = "Awesome!",
                            Score = 10
                        });
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.Material", b =>
                {
                    b.HasOne("EduMatApi.Models.Entities.Author", "Author")
                        .WithMany("Materials")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduMatApi.Models.Entities.MaterialType", "MaterialType")
                        .WithMany("Materials")
                        .HasForeignKey("MaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("MaterialType");
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.Review", b =>
                {
                    b.HasOne("EduMatApi.Models.Entities.Material", "Material")
                        .WithMany("Reviews")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.Author", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.Material", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("EduMatApi.Models.Entities.MaterialType", b =>
                {
                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}

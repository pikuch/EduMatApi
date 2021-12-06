using EduMatApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduMatApi.DAL
{
    public static class EduMatApiModelSeeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var authors = new Author[]
            {
                new Author() { Id = 1, Name = "Zuzanna", Description = "I'm sharing knowledge!" },
                new Author() { Id = 2, Name = "Wilhelm", Description = "Collector of tutorials" },
                new Author() { Id = 3, Name = "Ursula", Description = "Quality over quantity" },
                new Author() { Id = 4, Name = "Titus", Description = "The more I read the more I know" },
            };

            modelBuilder.Entity<Author>().HasData(authors);

            var materialTypes = new MaterialType[]
            {
                new MaterialType() { Id = 1, Name = "Video tutorial", Definition = "A tutorial in video form" },
                new MaterialType() { Id = 2, Name = "Presentation", Definition = "A video presentation" },
                new MaterialType() { Id = 3, Name = "Text tutorial", Definition = "A tutorial in text form" },
                new MaterialType() { Id = 4, Name = "Documentation", Definition = "Official documentation" },
                new MaterialType() { Id = 5, Name = "Interactive", Definition = "A learning resource you can learn from by interacting" },
            };

            modelBuilder.Entity<MaterialType>().HasData(materialTypes);

            var materials = new Material[]
            {
                new Material() { Id = 1, AuthorId = 1, TypeId = 1, Title = ".NET Core 3.1 MVC REST API - Full Course", Description = "In this full course, we show you how to build a full REST API using .NET Core 3.1", Location = "https://www.youtube.com/watch?v=fmvcAzHpsk8", PublishDate = DateTime.Now.AddDays(-30) },
                new Material() { Id = 2, AuthorId = 2, TypeId = 1, Title = "Introduction to ASP.NET Core MVC in C# plus LOTS of Tips", Description = " In this video, I am going to walk you through how MVC is set up, how authentication works, and how it is different from the .NET Framework version of MVC.", Location = "https://www.youtube.com/watch?v=1ck9LIBxO14", PublishDate = DateTime.Now.AddDays(-31) },
                new Material() { Id = 3, AuthorId = 3, TypeId = 1, Title = "ASP.NET core tutorial for beginners", Description = "Step by step asp.net core fundamentals course to help you build asp.net core mvc web applications from scratch following the asp.net core best practices and conventions.", Location = "https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU", PublishDate = DateTime.Now.AddDays(-32) },
                new Material() { Id = 4, AuthorId = 4, TypeId = 1, Title = "Secure a .NET Core API with Bearer Authentication", Description = "In this step by step tutorial, I show you how to secure a .NET Core API with JWT Bearer Authentication", Location = "https://www.youtube.com/watch?v=3PyUjOmuFic", PublishDate = DateTime.Now.AddDays(-33) },
                new Material() { Id = 5, AuthorId = 1, TypeId = 2, Title = "Tech Talk: Linus Torvalds on git", Description = "Linus Torvalds visits Google to share his thoughts on git, the source control management system he created two years ago.", Location = "https://www.youtube.com/watch?v=4XpnKHJAok8", PublishDate = DateTime.Now.AddDays(-34) },
                new Material() { Id = 6, AuthorId = 2, TypeId = 3, Title = "ASP.NET Core Identity Tutorial", Description = "Identity API tutorial", Location = "https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/", PublishDate = DateTime.Now.AddDays(-35) },
                new Material() { Id = 7, AuthorId = 3, TypeId = 3, Title = "ASP.NET Tutorial for Beginners", Description = "Learn .NET Basics in 3 Days", Location = "https://www.guru99.com/asp-net-tutorial.html", PublishDate = DateTime.Now.AddDays(-36) },
                new Material() { Id = 8, AuthorId = 4, TypeId = 3, Title = "HTTP Tutorial", Description = "Basic HTTP tutorial", Location = "https://www.tutorialspoint.com/http/index.htm", PublishDate = DateTime.Now.AddDays(-37) },
                new Material() { Id = 9, AuthorId = 1, TypeId = 4, Title = "Controller action return types", Description = "Controller action return types in ASP.NET Core web API", Location = "https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0", PublishDate = DateTime.Now.AddDays(-38) },
                new Material() { Id = 10, AuthorId = 2, TypeId = 4, Title = "HTTP Documentation", Description = "HTTP specs", Location = "https://httpwg.org/specs/", PublishDate = DateTime.Now.AddDays(-39) },
                new Material() { Id = 11, AuthorId = 1, TypeId = 5, Title = "Git branching", Description = "An interactive way to learn GIT branching", Location = "https://learngitbranching.js.org/", PublishDate = DateTime.Now.AddDays(-40) },
                new Material() { Id = 12, AuthorId = 4, TypeId = 5, Title = "Interactive learning", Description = "We'll be writing an api together next friday!", Location = "out school", PublishDate = DateTime.Now.AddDays(-41) },
            };

            modelBuilder.Entity<Material>().HasData(materials);

            var reviews = new Review[]
            {
                new Review() { Id = 1, MaterialId = 1, Score = 10, Opinion = "Just watch it."},
                new Review() { Id = 2, MaterialId = 1, Score = 9, Opinion = "Very good tutorial"},
                new Review() { Id = 3, MaterialId = 2, Score = 8, Opinion = "A lot of useful stuff in this one"},
                new Review() { Id = 4, MaterialId = 4, Score = 7, Opinion = "Get secured or get hacked!"},
                new Review() { Id = 5, MaterialId = 5, Score = 8, Opinion = "Good to watch"},
                new Review() { Id = 6, MaterialId = 5, Score = 3, Opinion = "Seems rude"},
                new Review() { Id = 7, MaterialId = 5, Score = 10, Opinion = "What a guy!"},
                new Review() { Id = 8, MaterialId = 6, Score = 10, Opinion = "I wouldn't know what to do without this guy"},
                new Review() { Id = 9, MaterialId = 7, Score = 9, Opinion = "Good stuff"},
                new Review() { Id = 10, MaterialId = 7, Score = 6, Opinion = "A bit too slow for me"},
                new Review() { Id = 11, MaterialId = 8, Score = 8, Opinion = "A gentle introduction"},
                new Review() { Id = 12, MaterialId = 10, Score = 3, Opinion = "Who has time for that?!"},
                new Review() { Id = 13, MaterialId = 11, Score = 6, Opinion = "Decent"},
                new Review() { Id = 14, MaterialId = 12, Score = 9, Opinion = "It was great, I learned so much!"},
                new Review() { Id = 15, MaterialId = 12, Score = 10, Opinion = "Cool"},
                new Review() { Id = 16, MaterialId = 12, Score = 10, Opinion = "Awesome!"},
            };

            modelBuilder.Entity<Review>().HasData(reviews);
        }
    }
}
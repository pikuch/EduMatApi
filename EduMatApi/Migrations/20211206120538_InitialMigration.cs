using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMatApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "I'm sharing knowledge!", "Zuzanna" },
                    { 2, "Collector of tutorials", "Wilhelm" },
                    { 3, "Quality over quantity", "Ursula" },
                    { 4, "The more I read the more I know", "Titus" }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "Definition", "Name" },
                values: new object[,]
                {
                    { 1, "A tutorial in video form", "Video tutorial" },
                    { 2, "A video presentation", "Presentation" },
                    { 3, "A tutorial in text form", "Text tutorial" },
                    { 4, "Official documentation", "Documentation" },
                    { 5, "A learning resource you can learn from by interacting", "Interactive" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "AuthorId", "Description", "Location", "MaterialTypeId", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "In this full course, we show you how to build a full REST API using .NET Core 3.1", "https://www.youtube.com/watch?v=fmvcAzHpsk8", 1, new DateTime(2021, 11, 6, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2867), ".NET Core 3.1 MVC REST API - Full Course" },
                    { 2, 2, " In this video, I am going to walk you through how MVC is set up, how authentication works, and how it is different from the .NET Framework version of MVC.", "https://www.youtube.com/watch?v=1ck9LIBxO14", 1, new DateTime(2021, 11, 5, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2899), "Introduction to ASP.NET Core MVC in C# plus LOTS of Tips" },
                    { 3, 3, "Step by step asp.net core fundamentals course to help you build asp.net core mvc web applications from scratch following the asp.net core best practices and conventions.", "https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU", 1, new DateTime(2021, 11, 4, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2901), "ASP.NET core tutorial for beginners" },
                    { 4, 4, "In this step by step tutorial, I show you how to secure a .NET Core API with JWT Bearer Authentication", "https://www.youtube.com/watch?v=3PyUjOmuFic", 1, new DateTime(2021, 11, 3, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2903), "Secure a .NET Core API with Bearer Authentication" },
                    { 5, 1, "Linus Torvalds visits Google to share his thoughts on git, the source control management system he created two years ago.", "https://www.youtube.com/watch?v=4XpnKHJAok8", 2, new DateTime(2021, 11, 2, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2905), "Tech Talk: Linus Torvalds on git" },
                    { 6, 2, "Identity API tutorial", "https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/", 3, new DateTime(2021, 11, 1, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2907), "ASP.NET Core Identity Tutorial" },
                    { 7, 3, "Learn .NET Basics in 3 Days", "https://www.guru99.com/asp-net-tutorial.html", 3, new DateTime(2021, 10, 31, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2909), "ASP.NET Tutorial for Beginners" },
                    { 8, 4, "Basic HTTP tutorial", "https://www.tutorialspoint.com/http/index.htm", 3, new DateTime(2021, 10, 30, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2911), "HTTP Tutorial" },
                    { 9, 1, "Controller action return types in ASP.NET Core web API", "https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0", 4, new DateTime(2021, 10, 29, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2913), "Controller action return types" },
                    { 10, 2, "HTTP specs", "https://httpwg.org/specs/", 4, new DateTime(2021, 10, 28, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2916), "HTTP Documentation" },
                    { 11, 1, "An interactive way to learn GIT branching", "https://learngitbranching.js.org/", 5, new DateTime(2021, 10, 27, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2917), "Git branching" },
                    { 12, 4, "We'll be writing an api together next friday!", "out school", 5, new DateTime(2021, 10, 26, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2919), "Interactive learning" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "MaterialId", "Opinion", "Score" },
                values: new object[,]
                {
                    { 1, 1, "Just watch it.", 10 },
                    { 2, 1, "Very good tutorial", 9 },
                    { 3, 2, "A lot of useful stuff in this one", 8 },
                    { 4, 4, "Get secured or get hacked!", 7 },
                    { 5, 5, "Good to watch", 8 },
                    { 6, 5, "Seems rude", 3 },
                    { 7, 5, "What a guy!", 10 },
                    { 8, 6, "I wouldn't know what to do without this guy", 10 },
                    { 9, 7, "Good stuff", 9 },
                    { 10, 7, "A bit too slow for me", 6 },
                    { 11, 8, "A gentle introduction", 8 },
                    { 12, 10, "Who has time for that?!", 3 },
                    { 13, 11, "Decent", 6 },
                    { 14, 12, "It was great, I learned so much!", 9 },
                    { 15, 12, "Cool", 10 },
                    { 16, 12, "Awesome!", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_AuthorId",
                table: "Materials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MaterialId",
                table: "Reviews",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "MaterialTypes");
        }
    }
}

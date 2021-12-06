using EduMatApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Educational Materials API",
        Description = "An ASP.NET Core Web API for managing Educational Materials"
    }
    );
});
builder.Services.AddDbContext<EduMatApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:EduMatApiDbConnection"]));
builder.Services.AddCors(options =>
    options.AddPolicy(name: "AllowAllOrigins",
                      builder => builder.AllowAnyOrigin()
                      )
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();

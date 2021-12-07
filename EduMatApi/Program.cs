using EduMatApi.DAL;
using EduMatApi.DAL.Repositories;
using EduMatApi.Filters;
using EduMatApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
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

    options.EnableAnnotations();
});

builder.Services.AddDbContext<EduMatApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:EduMatApiDbConnection"]));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:UserDbConnection"]));
builder.Services.AddCors(options =>
    options.AddPolicy(name: "AllowAllOrigins",
                      builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                      )
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRepository<Author>, Repository<Author>>();
builder.Services.AddScoped<IRepository<Material>, Repository<Material>>();
builder.Services.AddScoped<IRepository<MaterialType>, Repository<MaterialType>>();
builder.Services.AddScoped<IRepository<Review>, Repository<Review>>();
builder.Services.AddMvc(options => options.Filters.Add<EduMatApiExceptionFilter>());
builder.Services.AddScoped<ILogger<EduMatApiExceptionFilter>, Logger<EduMatApiExceptionFilter>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "EduMat API V1");
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

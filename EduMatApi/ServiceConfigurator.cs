using EduMatApi.Authentication;
using EduMatApi.DAL;
using EduMatApi.DAL.Repositories;
using EduMatApi.Filters;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace EduMatApi
{
    public static class ServiceConfigurator
    {
        public static void ConfigureServices(
            this IServiceCollection services,
            string secretKey,
            string EduMatApiDbConnection,
            string UserDbConnection)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // enable in production
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
                };
            });

            services.AddSingleton<IJwtAuthenticator>(new JwtAuthenticator(secretKey));

            services.AddDbContext<EduMatApiDbContext>(options =>
                options.UseSqlServer(EduMatApiDbConnection));
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(UserDbConnection));
            services.AddCors(options =>
                options.AddPolicy(name: "AllowAllOrigins",
                                  builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                                  )
                );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IRepository<Material>, Repository<Material>>();
            services.AddScoped<IRepository<MaterialType>, Repository<MaterialType>>();
            services.AddScoped<IRepository<Review>, Repository<Review>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMvc(options => options.Filters.Add<EduMatApiExceptionFilter>());
            services.AddScoped<ILogger<EduMatApiExceptionFilter>, Logger<EduMatApiExceptionFilter>>();
        }
    }
}

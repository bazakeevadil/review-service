using Application.Contract;
using Domain.Entities;
using Mapster;

namespace WebApi;

public static class ConfigureServices
{

    public static IServiceCollection AddAuth(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        TypeAdapterConfig<Course, CourseDto>.NewConfig().MaxDepth(2).PreserveReference(true);
        TypeAdapterConfig<Review, ReviewDto>.NewConfig().MaxDepth(2).PreserveReference(true);

        services.AddAuthentication(opts =>
        {
            opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(opts =>
        {
            opts.SaveToken = true;
            opts.RequireHttpsMetadata = false;
            opts.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(
                            configuration["WEBAPI_JWT"] ??
                                throw new Exception("JWT was not found!!!"))),
            };
        });

        return services;
    }

    public static IServiceCollection AddSwagger(
       this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ReviewerApi",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        return services;
    }

    public static IServiceCollection AddAnyCors(
       this IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy("DefaultPolicy",
        builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

        return services;
    }
}

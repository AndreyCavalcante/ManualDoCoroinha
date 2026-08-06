    using ManualDoCoroinha.Context;
    using ManualDoCoroinha.DTOs.Mappings;
    using ManualDoCoroinha.Filters;
    using ManualDoCoroinha.Models.Users;
    using ManualDoCoroinha.Repositories;
using ManualDoCoroinha.Repositories.Lessons;
using ManualDoCoroinha.Repositories.Modules;
    using ManualDoCoroinha.Repositories.Prayers;
    using ManualDoCoroinha.Repositories.Quizzes;
    using ManualDoCoroinha.Repositories.UserFavoritePrayers;
    using ManualDoCoroinha.Repositories.Users;
    using ManualDoCoroinha.Services;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System.Text;
    using System.Text.Json.Serialization;

    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(ApiExceptionFilter));
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "ManualDoCoroinha",
            Version = "v1"
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Bearer JWT "
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
                new string[] { }
            }
        });
    });

    builder.Services.AddIdentity<User, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

    string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

    var secretKey = builder.Configuration["JWT:SecretKey"]
        ?? throw new ArgumentException("Invalid secret key!!");

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey))
        };
    });

    builder.Services.AddAuthorization();

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IPrayerRepository, PrayerRepository>();
    builder.Services.AddScoped<IUserFavoritePrayerRepository, UserFavoritePrayerRepository>();
    builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
    builder.Services.AddScoped<IQuizRepository, QuizRepository>();
    builder.Services.AddScoped<ILessonRepository, LessonRepository>();
    builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();

    builder.Services.AddScoped<ITokenService, TokenService>();

    builder.Services.AddAutoMapper(typeof(PrayerDtoMappingProfile));
    builder.Services.AddAutoMapper(typeof(FavoritePrayerDtoMappingProfile));
    builder.Services.AddAutoMapper(typeof(UserDtoMappingProfile));
    builder.Services.AddAutoMapper(typeof(ModuleDtoMappingProfile));
    builder.Services.AddAutoMapper(typeof(QuizDtoMappingProfile));
    builder.Services.AddAutoMapper(typeof(QuestionDtoMappingProfile));
    builder.Services.AddAutoMapper(typeof(AlternativeDtoMappingsProfile));

    var app = builder.Build();

// Aplica as migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

    // Configure the HTTP request pipeline.
  
    app.UseSwagger();
    app.UseSwaggerUI();
    

    //app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

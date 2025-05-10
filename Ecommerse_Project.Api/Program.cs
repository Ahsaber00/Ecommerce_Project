using System.Text;
using Ecommerce__Project.Api.Mappings;
using Ecommerse_Project.BLL.Dtos.UserDtos;
using Ecommerse_Project.BLL.Interfaces;
using Ecommerse_Project.BLL.Manager;
using Ecommerse_Project.BLL.Services;
using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using Ecommerse_Project.DAL.Repositories;
using Ecommerse_Project.DAL.Repositories.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add JWT Authentication support in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field (e.g., 'Bearer <token>')",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt")); 
builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
}, ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Register the generic repository to be used by the project repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


// Register UnitOfWork (which includes repositories)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//For image handling in the wwwroot
builder.Services.AddSingleton<IFileProvider>(provider =>
    new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath)));
builder.Services.AddScoped<IImageManagementService,ImageManagementService>();

//Managers Register
builder.Services.AddScoped<IaccountManager, AccountManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();  
builder.Services.AddScoped<ICartManager,CartManager>();
builder.Services.AddScoped<IuserAuthenticationManager, UserAuthenticationManager>();    
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddHttpContextAccessor();


//register redis to make caching for the cart
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var configOptions = ConfigurationOptions.Parse(config.GetConnectionString("Redis"));
    configOptions.AbortOnConnectFail = false;
    return ConnectionMultiplexer.Connect(configOptions);
});


// Register authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
    var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

    options.TokenValidationParameters = new TokenValidationParameters
    {

        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,



    };
});



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();

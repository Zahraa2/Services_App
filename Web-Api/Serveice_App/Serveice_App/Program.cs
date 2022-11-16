using BL;
using BL;
using BL.Managers.UserManager;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
#region Services

#region Asp Identity

builder.Services.AddIdentity<CustomeUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
})
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

#endregion

#region auth
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.Configure<MailSetting>(builder.Configuration.GetSection("Mailsetting"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Auth";
    options.DefaultChallengeScheme = "Auth";
})
.AddJwtBearer("Auth", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:Key"]))

    };
});
#endregion

#region Default
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Database

var connectionString = builder.Configuration.GetConnectionString("ServiceDb");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

#endregion

#region Reposatories
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICustomerRepo, CutomerRepo>();
builder.Services.AddScoped<IMediaRepo, MediaRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<IProviderRepo, ProviderRepo>();
builder.Services.AddScoped<IRequestRepo, RequestRepo>();
builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

#endregion

#region Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
#endregion

#region Managers
builder.Services.AddScoped<ICategoryManger,CategoryManger>();
builder.Services.AddScoped<IServiceManger,ServiceManger>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<ICustomUserManager, CustomUserManager>();
builder.Services.AddScoped<IProviderUser, ProviderUser>();
builder.Services.AddScoped<IProviderManger, ProviderManger>();
builder.Services.AddScoped<IPostManger, PostManger>();

#endregion

#endregion


#region core

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});


#endregion

var app = builder.Build();

#region Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion

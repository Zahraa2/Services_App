using Microsoft.EntityFrameworkCore;
using Services.BL;
using Services.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Services

#region Default
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Database

var connectionString = builder.Configuration.GetConnectionString("ServicesDb");
builder.Services.AddDbContext<ServicesContext>(options => options.UseSqlServer(connectionString));

#endregion

#region Repos

#endregion

#region Unit Of Work
#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

#endregion

#region Managers
#endregion

#endregion


var app = builder.Build();

#region Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion

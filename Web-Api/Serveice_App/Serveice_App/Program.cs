using DAL;
using Microsoft.EntityFrameworkCore;


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

var connectionString = builder.Configuration.GetConnectionString("ServiceDb");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

#endregion

#region Repos

#endregion

#region Unit Of Work
#endregion

#region AutoMapper


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

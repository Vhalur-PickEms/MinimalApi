using Microsoft.EntityFrameworkCore;
using MinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultCon")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("Team")
    .MapTeamApi();

#region Startup
app.UseHttpsRedirection();

app.UseCors(options =>
     options.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());

app.UseCors(options =>
     options.WithOrigins("http://localhost:7020")
            .AllowAnyHeader()
            .AllowAnyMethod());

#endregion

app.Run();

public partial class Program { }
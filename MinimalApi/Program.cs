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

app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World!");

var teams = app.MapGroup("/Teams");
var match = app.MapGroup("/Match");

teams.MapGet("/", GetAllTeams);
teams.MapGet("/{id}", GetTeamById);
teams.MapPost("/", CreateTeam);
teams.MapPut("/{id}", UpdateTeam);
teams.MapDelete("/{id}", DeleteTeam);

match.MapGet("/", GetAllMatches);
match.MapPost("/", CreateMatch);


static async Task<IResult> GetAllMatches(DataContext db)
{
    return TypedResults.Ok(await db.Match.ToArrayAsync());
}

static async Task<IResult> CreateMatch(Match match, DataContext db)
{
    db.Match.Add(match);
    await db.SaveChangesAsync();
    return TypedResults.Created($"/GetTeamByID/{match.Id}", match);
}

static async Task<IResult> GetAllTeams(DataContext db)
{
    return TypedResults.Ok(await db.Team.ToArrayAsync());
}

static async Task<IResult> GetTeamById(int id, DataContext db)
{
    return await db.Team.FindAsync(id) is Team team ? TypedResults.Ok(team) : TypedResults.NotFound();
}

static async Task<IResult> CreateTeam(Team team, DataContext db)
{
    db.Team.Add(team);
    await db.SaveChangesAsync();
    return TypedResults.Created($"/GetTeamByID/{team.Id}", team);
}

static async Task<IResult> UpdateTeam(int id, Team inputTeam, DataContext db)
{
    Team team = await db.Team.FindAsync(id) ?? throw new ArgumentException(nameof(team));
    if (team is null) return TypedResults.NotFound();  

    team.Name = inputTeam.Name;
    team.LogoUrl = inputTeam.LogoUrl;

    await db.SaveChangesAsync();
    return TypedResults.Created($"/GetTeamByID/{team.Id}", team);
}

static async Task<IResult> DeleteTeam(int id, DataContext db)
{
    if (await db.Team.FindAsync(id) is Team team)
    {
        db.Team.Remove(team);
        await db.SaveChangesAsync();
        return TypedResults.Ok(team);
    }
    return TypedResults.NotFound();
}

app.UseCors(options =>
     options.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());

app.UseCors(options =>
     options.WithOrigins("http://localhost:7020")
            .AllowAnyHeader()
            .AllowAnyMethod());
app.Run();

public partial class Program { }
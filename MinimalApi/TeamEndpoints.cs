using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.IO;

namespace MinimalApi;

public static class TeamEndpoints
{
    public static RouteGroupBuilder MapTeamApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllTeams);

        return group;
    }

    public static async Task<Ok<List<Team>>> GetAllTeams(DataContext db)
    {
        List<Team> teams = await db.Team.ToListAsync();
        return TypedResults.Ok(teams);
    }
}

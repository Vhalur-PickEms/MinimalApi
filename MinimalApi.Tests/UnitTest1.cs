using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalApi.Tests;

public class UnitTest1
{
    [Fact]
    public async Task TestPostMethod()
    {
        // Arrange
        await using var context = new MockDb().CreateDbContext();

        context.Team.Add(new Team(1, "G2", null));

        await context.SaveChangesAsync();

        // Act
        var result = await TeamEndpoints.GetAllTeams(context);

        // Assert
        Assert.IsType<Ok<List<Team>>>(result);
        Assert.NotNull(result.Value);
        Assert.Collection(result.Value, team1 =>
        {
            Assert.Equal(1, team1.Id);
            Assert.Equal("G2", team1.Name);
            Assert.Null(team1.LogoUrl);
        });
        // HAHAH XD
    }
}
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace MinimalApi.Tests;

public class UnitTest1
{
    [Fact]
    public async Task TestRootEndpoint()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        // Act
        var response = await client.GetAsync("/Teams");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}
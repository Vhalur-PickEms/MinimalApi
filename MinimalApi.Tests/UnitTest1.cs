using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace MinimalApi.Tests;

public class UnitTest1
{
    [Fact]
    public async Task test1()
    {
        // Arrange 
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        // Act
        var response = await client.GetStringAsync("/");

        // Assert
        Assert.Equal("Hello World!", response);

    }
}
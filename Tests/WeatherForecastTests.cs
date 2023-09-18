using Xunit.Abstractions;

namespace Tests;

public class BasicTests 
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public BasicTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
    {
        _factory = factory;
        _factory.Output = output;
    }

    [Fact]
    public async Task Get1()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/");
        response.EnsureSuccessStatusCode();
    }
    
    [Fact]
    public async Task Get2()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/");
        Assert.True(false);
    }
}

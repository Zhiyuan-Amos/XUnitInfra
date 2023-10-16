using Meziantou.Extensions.Logging.Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public ITestOutputHelper Output { get; set; } = null!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // https://www.youtube.com/watch?v=dasbRVz5MXo&t=553s
        builder.ConfigureLogging(b =>
        {
            b.ClearProviders();
            b.Services.AddSingleton<ILoggerProvider>(new XUnitLoggerProvider(Output));
        });
    }
}

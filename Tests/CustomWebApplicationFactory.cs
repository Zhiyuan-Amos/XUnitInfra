using Meziantou.Extensions.Logging.Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public ITestOutputHelper Output { get; set; } = null!;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        // builder.UseSerilog((_, _, configuration) => {
        //     configuration.WriteTo.TestOutput(Output);
        // });
        return base.CreateHost(builder);
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(b =>
        {
            b.ClearProviders();
            b.Services.AddSingleton<ILoggerProvider>(new XUnitLoggerProvider(Output));
        });
    }
}

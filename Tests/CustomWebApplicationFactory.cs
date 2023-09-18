using Microsoft.AspNetCore.Mvc.Testing;
using Serilog;
using Xunit.Abstractions;

namespace Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public ITestOutputHelper Output { get; set; } = null!;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseSerilog((_, _, configuration) => {
            configuration.WriteTo.TestOutput(Output);
        });
        return base.CreateHost(builder);
    }

    // protected override void ConfigureWebHost(IWebHostBuilder builder)
    // {
    //     builder.ConfigureServices(services =>
    //     {
    //         // https://andrewlock.net/converting-integration-tests-to-net-core-3/
    //         services.AddLogging(b =>
    //         {
    //             b.ClearProviders();
    //             b.AddXUnit(Output, options => options.TimestampFormat = "O");
    //         });
    //     });
    // }
}
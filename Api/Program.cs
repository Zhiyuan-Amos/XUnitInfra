using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((_, _, configuration) => {
    configuration.WriteTo.Console();
});
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();

public partial class Program { }

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TestHandler>();

var app = builder.Build();
var handler = app.Services.GetRequiredService<TestHandler>();
//app.MapGet("/", () => "Hello World!");
app.MapGet("/", handler.HandleRequest);

app.Run();

partial class TestHandler(ILogger<TestHandler> logger)
{
    public string HandleRequest()
    {
        LogHandleRequest(logger);
        return "Hello World";
    }

    [LoggerMessage(LogLevel.Information, "TestHandler.HandleRequest was called")]
    public static partial void LogHandleRequest(ILogger logger);
}
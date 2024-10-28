var builder = WebApplication.CreateBuilder(args);


/* Following code will add configuration from various souces.builder.Configuration.Sources
    
    How ever ASP.NET CORE minimal will load all configuration from all sources automatically
    so below code is not required to write additionally.
 */

/*
    builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    var EnvironmentName = Environment.GetEnvironmentVariable("Environment")??string.Empty;

    if (!builder.Environment.IsProduction())
    {
    builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
    }
    if (builder.Environment.IsDevelopment())
    {
        builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
    }
 */
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


//The GetRequiredService method is used to retrieve the configuration object from the application’s services collection.
  var config = app.Services.GetRequiredService<IConfiguration>();
  $"User Key1 from user secrets:{config.GetValue<string>("UserKey1")}".Display();
  $"User Key2 from user secrets:{config.GetValue<string>("UserKey2")}".Display();
  $"OS from Environment Variables:{config.GetValue<string>("OS")}".Display();

  var section = config.GetSection("MySettings");
// Bind a configuration section to a strongly-typed object
var MySettings=section.Get<DTO.MySettings>();
MySettings.Display(()=>MySettings);

var Setting1 = section["Setting1"];
Setting1?.Display(nameof(Setting1));

var connectionString = config.GetConnectionString("DefaultConnection");
connectionString.Display(()=>connectionString);

var logLevelDefault = config.GetValue<string>("Logging:LogLevel:Default");
logLevelDefault.Display(()=>logLevelDefault);

app.Run();

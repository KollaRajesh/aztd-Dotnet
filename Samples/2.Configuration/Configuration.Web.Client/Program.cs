using System.Reflection;

/*Pass Command line arguments to builder*/
// args = new string[]{
//     "Environment:Development",
//     "NETCORE_ENVIRONMENT:Development",
//     "ASPNETCORE_ENVIRONMENT:Development",
// };

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

   // Register the configuration object as a singleton
    //app.services.AddSingleton(config);

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


//static bool IsDevelopment(string environmentName) => environmentName == "Development"; 

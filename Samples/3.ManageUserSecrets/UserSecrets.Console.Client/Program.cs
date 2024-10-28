// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Reflection;

// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

//read environment variable from machine level scope
//var EnvironmentName= Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.Machine);  
//var EnvironmentName= Environment.GetEnvironmentVariable("Environment")

//read environment variable from User level scope
//var EnvironmentName= Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.User);



var EnvironmentName = Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.User)??string.Empty;
var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
if (IsDevelopment(EnvironmentName))
{
   builder.AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true,reloadOnChange: true)
          .AddUserSecrets(Assembly.GetExecutingAssembly());
        //builder.AddUserSecrets<Program>();
}
builder.AddEnvironmentVariables();

var configuration = builder.Build();

$"User Key1 from user secrets:{configuration.GetValue<string>("UserKey1")}".Display();
$"User Key2 from user secrets:{configuration.GetValue<string>("UserKey2")}".Display();

$"OS from Environment Variables:{configuration.GetValue<string>("OS")}".Display();

var section = configuration.GetSection("MySettings");

var MySettings=section.Get<DTO.MySettings>();
MySettings.Display(()=>MySettings);

var Setting1 = section["Setting1"];
Setting1?.Display(nameof(Setting1));

var connectionString = configuration.GetConnectionString("DefaultConnection");
connectionString.Display(()=>connectionString);

var logLevelDefault = configuration.GetValue<string>("Logging:LogLevel:Default");
logLevelDefault.Display(()=>logLevelDefault);

//Console.ReadKey();  
static bool IsDevelopment(string environmentName) => environmentName == "Development"; 
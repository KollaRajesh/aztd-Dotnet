using System.Globalization;
using System.Reflection;

// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

//var EnvironmentName= Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.Machine);
//var EnvironmentName= Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.User);
var EnvironmentName = Environment.GetEnvironmentVariable("Environment")??string.Empty;
var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
if (IsDevelopment(EnvironmentName))
{
   builder.AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true,reloadOnChange: true)
          .AddUserSecrets(Assembly.GetExecutingAssembly());
        //builder.AddUserSecrets<Program>();
}

var configuration = builder.Build();
var section = configuration.GetSection("MySettings");

var MySettings=section.Get<DTO.MySettings>();
MySettings.Display(()=>MySettings);

var Setting1 = section["Setting1"];
Setting1?.Display(nameof(Setting1));

var connectionString = configuration.GetConnectionString("DefaultConnection");
connectionString.Display(()=>connectionString);

var logLevelDefault = configuration.GetValue<string>("Logging:LogLevel:Default");
logLevelDefault.Display(()=>logLevelDefault);

static bool IsDevelopment(string environmentName) => environmentName == "Development"; 
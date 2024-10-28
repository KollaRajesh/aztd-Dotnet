using System.Runtime.InteropServices.ComTypes;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using DTO.Interfaces;
using DTO;
using DI.Data;

// Get the environment variable "Environment". If it doesn't exist, use an empty string.
var EnvironmentName = Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.User)??string.Empty;

// Create a new configuration builder.
var builder = new ConfigurationBuilder()
                     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to the current directory.
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); // Add the appsettings.json file to the configuration.

// If the environment is "Development", add the development appsettings and user secrets to the configuration.
if (IsDevelopment(EnvironmentName))
{
   builder.AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true,reloadOnChange: true) // Add the development appsettings.json file to the configuration.
          .AddUserSecrets(Assembly.GetExecutingAssembly()); // Add the user secrets to the configuration.
}

builder.AddEnvironmentVariables(); // Add the environment variables to the configuration.

// Build the configuration.
var configurationRoot  = builder.Build();

// Create a new service collection and add services to it.
var services = new ServiceCollection()
                .AddSingleton<IConfiguration>(configurationRoot) // Add the configuration as a singleton service.
                 .AddTransient<IPerson, Person>() // Add the Person class as a transient service.
                  .AddSingleton<PersonRepository>() // Add the PersonRepository class as a singleton service.
                .BuildServiceProvider(); // Build the service provider.

// Get the configuration from the service provider.
var config = services.GetRequiredService<IConfiguration>();

// Get a Person object from the service provider.
IPerson? person = services.GetService<IPerson>();
if (person != null)
{
  person.FirstName = "Scott"; // Set the first name of the person.
  person.LastName = "Morton"; // Set the last name of the person.
  person.Display(); // Display the person.
}
// Get a PersonRepository object from the service provider.
PersonRepository? personRepository = services.GetService<PersonRepository>();
if(personRepository!=null)
$"{personRepository}".Display(); // Display the PersonRepository object.

// Display the user secrets and environment variables.
$"User Key1 from user secrets:{config.GetValue<string>("UserKey1")}".Display();
$"User Key2 from user secrets:{config.GetValue<string>("UserKey2")}".Display();
$"OS from Environment Variables:{config.GetValue<string>("OS")}".Display();

// Get the "MySettings" section from the configuration.
var section = config.GetSection("MySettings");

// Get the MySettings object from the section.
var MySettings=section.Get<DTO.MySettings>();
MySettings.Display(()=>MySettings); // Display the MySettings object.

// Get the "Setting1" value from the section.
var Setting1 = section["Setting1"];
Setting1?.Display(nameof(Setting1)); // Display the "Setting1" value.

// Get the default connection string from the configuration.
var connectionString = config.GetConnectionString("DefaultConnection");
connectionString.Display(()=>connectionString); // Display the connection string.

// Get the default log level from the configuration.
var logLevelDefault = config.GetValue<string>("Logging:LogLevel:Default");
logLevelDefault.Display(()=>logLevelDefault); // Display the default log level.

// Method to check if the environment is "Development".
static bool IsDevelopment(string environmentName) => environmentName == "Development";

using System.Runtime.InteropServices.ComTypes;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using DTO.Interfaces;
using DTO;
using DI.Data;


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

var configurationRoot  = builder.Build();

//IConfigurationRoot is derived from IConfiguration and represents the root of an IConfiguration hierarchy. 
//You can use an instance of IConfigurationRoot as an instance of IConfiguration.
//var configurationRoot  = builder.Build();
//  IConfiguration configuration = configurationRoot;

//Build Service Provider with  ServiceCollection 
var services = new ServiceCollection()
                .AddSingleton<IConfiguration>(configurationRoot)
               // .AddSingleton<IConfigurationRoot>(configurationRoot) // its not required as IConfigurationRoot is derived from IConfiguration
                 .AddTransient<IPerson, Person>()
                  .AddSingleton<PersonRepository>()
                // .AddTransient<IPerson,Person>(_ => new Person("Rob", "Michelle"))
                .BuildServiceProvider();

//var _serviceProvider= services.GetService<IServiceProvider>();
//var config = _serviceProvider.GetService<IConfiguration>();

var config = services.GetService<IConfiguration>();

  IPerson person = services.GetService<IPerson>();
    person.FirstName = "Scott";
    person.LastName = "Morton";
person.Display();

 var personRepository = services.GetService<PersonRepository>();
$"{personRepository}".Display();



$"User Key1 from user secrets:{config.GetValue<string>("UserKey1")}".Display();
$"User Key2 from user secrets:{config.GetValue<string>("UserKey2")}".Display();

$"OS from Environment Variables:{config.GetValue<string>("OS")}".Display();

var section = config.GetSection("MySettings");

var MySettings=section.Get<DTO.MySettings>();
MySettings.Display(()=>MySettings);

var Setting1 = section["Setting1"];
Setting1?.Display(nameof(Setting1));

var connectionString = config.GetConnectionString("DefaultConnection");
connectionString.Display(()=>connectionString);

var logLevelDefault = config.GetValue<string>("Logging:LogLevel:Default");
logLevelDefault.Display(()=>logLevelDefault);

//Console.ReadKey();  
static bool IsDevelopment(string environmentName) => environmentName == "Development"; 

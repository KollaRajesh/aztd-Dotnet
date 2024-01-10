// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = builder.Build();
var section = configuration.GetSection("MySettings");

var MySettings=section.Get<DTO.MySettings>();
MySettings.Display(()=>MySettings);

var Setting1 = section["Setting1"];
Setting1.Display(nameof(Setting1));

var connectionString = configuration.GetConnectionString("DefaultConnection");
connectionString.Display(()=>connectionString);

var logLevelDefault = configuration.GetValue<string>("Logging:LogLevel:Default");
logLevelDefault.Display(()=>logLevelDefault);

Console.ReadKey();
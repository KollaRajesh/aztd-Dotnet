using DTO.Interfaces;
using DTO;
using DI.Data;
var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

//Build Service Provider with  ServiceCollection 
builder.Services.AddSingleton<IConfiguration>(configuration)
                 .AddTransient<IPerson, Person>()
                  .AddSingleton<PersonRepository>()
                // .AddTransient<IPerson,Person>(_ => new Person("Rob", "Michelle"))
                .BuildServiceProvider();

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

app.MapGet("/", () => "Hello DI!");

  var config= app.Services.GetService<IConfigurationRoot>();
  
  IPerson person = app.Services.GetService<IPerson>();
    person.FirstName = "Scott";
    person.LastName = "Morton";
    person.Display();

  var personRepository = app.Services.GetService<PersonRepository>();
  $"{personRepository}".Display();

app.Run();

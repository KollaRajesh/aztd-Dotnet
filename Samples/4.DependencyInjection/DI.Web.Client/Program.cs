using DTO.Interfaces;
using DTO;
using DI.Data;

// Create a new builder for the web application
var builder = WebApplication.CreateBuilder(args);

// Get the configuration from the builder
// IConfiguration configuration = ;

//Build Service Provider with  ServiceCollection 
builder.Services
       .AddSingleton<IConfiguration>(builder.Configuration)   // Add the configuration as a singleton service
        .AddTransient<IPerson, Person>()   // Add the Person class as a transient service
        .AddSingleton<PersonRepository>()   // Add the PersonRepository class as a singleton service
        .AddSingleton<TestHandler>();  // Add the TestHandler class as a singleton service
     // .AddTransient<IPerson,Person>(_ => new Person("Rob", "Michelle"))
     // .BuildServiceProvider();   // Build the service provider   //The warning ASP0000: Calling 'BuildServiceProvider' from application code results in an additional copy of singleton services being created is issued when you manually call BuildServiceProvider in your application code.

     /*This is because calling BuildServiceProvider creates a second container, which can create torn singletons and cause references to object graphs across multiple containers.
      This might result in more than one copy of singleton services being created which might result in incorrect application behavior.*/

#region Commented

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
#endregion

// Build the web application
 var app = builder.Build();

// Get the TestHandler service
var handler = app.Services.GetRequiredService<TestHandler>();
//app.MapGet("/", () => "Hello DI!");

// Map the root ("/") GET request to the HandleRequest method of the handler
app.MapGet("/", handler.HandleRequest);

// Get the configuration service
  var config= app.Services.GetService<IConfigurationRoot>();
  
// Get the Person service and set its properties
  IPerson? person = app.Services.GetService<IPerson>();
if (person != null)
{
  person.FirstName = "Scott";
  person.LastName = "Morton";
  // Display the person's information
  person.Display();
}
// Get the PersonRepository service and display its information
  var personRepository = app.Services.GetService<PersonRepository>();
  if(personRepository !=null)
  $"{personRepository}".Display();

// Run the web application
app.Run();




// Define a partial class for the TestHandler
partial class TestHandler(ILogger<TestHandler> logger)
{
    // Define a method to handle requests
    public string HandleRequest()
    {
        // Log the request handling
        LogHandleRequest(logger);

        // Return a response
        return "Hello DI by TestHandler!";
    }

  // Define a method to log the request handling
    [LoggerMessage(LogLevel.Information, "TestHandler.HandleRequest was called")]
    public static partial void LogHandleRequest(ILogger logger);
}

> ### Overview of Microsoft.Extensions.Configuration

1. **Microsoft.Extensions.Configuration** is a package in .NET that provides a unified API for reading key-value pairs from various configuration sources.  
   - It’s the foundation for configuration in .NET apps.  
   - It provides the ConfigurationBuilder and related types, which are used to build key/value-based configuration settings for use in an application.  


 ```sh
    # Syntax: 
         dotnet add [<PROJECT>] package <PACKAGE_NAME>
     # Example   
        cd  .\Configuration.Console.Client

        dotnet add package Microsoft.Extensions.Configuration  
```

```cs 
using Microsoft.Extensions.Configuration;
var builder = new ConfigurationBuilder()
```
---
2. **Microsoft.Extensions.Configuration.Json** is a specific configuration provider that allows you to read your application’s settings from a JSON file. 
  - It provides the JsonConfigurationProvider class which loads configuration from a JSON file.

 ```sh
    # Syntax: 
         dotnet add [<PROJECT>] package <PACKAGE_NAME>
     # Example   
        cd  .\Configuration.Console.Client
         
        dotnet add package Microsoft.Extensions.Configuration.Json  
```

```cs 
using Microsoft.Extensions.Configuration;
var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

IConfiguration config = builder.Build();


Console.WriteLine($"Server: {config["Settings:Server"]}");
Console.WriteLine($"Database: {config["Settings:Database"]}");

/*In this example, appsettings.json is the JSON file from which the configuration is read.
 The SetBasePath method sets the base path for the JSON file, and AddJsonFile adds the JSON configuration file to the configuration builder.
 
 The Build method builds the configuration, and the values are accessed using the indexer with the key.
 
 The keys are the names of the settings in the JSON file.
 
  For instance, if the JSON file contains a setting like "Settings:Server": "example.com", you can access the value with config["Settings:Server"]
 */
```
---
3. **Microsoft.Extensions.Configuration.Binder** is a package in .NET that provides functionality to bind an object to data in configuration providers.
  - This allows you to represent the configuration data as strongly-typed classes defined in the application code.
  - The ConfigurationBinder.Get extension method on the IConfiguration object is used to bind a configuration.
  - This package also provides a source generator which generates source to bind objects from a configuration section without a runtime reflection dependency.

 ```sh
    # Syntax: 
         dotnet add [<PROJECT>] package <PACKAGE_NAME>
     # Example   
        cd  .\Configuration.Console.Client
    
        dotnet add package Microsoft.Extensions.Configuration.Binder
```

```cs 
using Microsoft.Extensions.Configuration;

class Settings 
{
    public string Server { get; set; }
    public string Database { get; set; }
}
IConfiguration config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

// Bind a configuration section to an instance of Settings class
Settings settings = config.GetSection("Settings").Get<Settings>();
Console.WriteLine($"Server: {settings.Server}");
Console.WriteLine($"Database: {settings.Database}");

/*In this example, the appsettings.json file contains the configuration.

The GetSection method gets the “Settings” section from the configuration, and the Get<Settings> method binds the configuration section to an instance of the Settings class.
The values are then accessed through the properties of the Settings class.
This allows for a strongly-typed, object-oriented approach to handling configuration data*/
```


> - Note: No need to add these packages in Web application , Web App project internally refer these packages.
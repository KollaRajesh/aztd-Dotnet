> Logging - Serilog

- Serilog is a popular .NET logging library that provides flexibility, extensibility, and structured logging capabilities.
- Unlike other logging libraries, Serilog is built with powerful structured event data in mind. It makes it easy to record custom object properties and even output your logs to JSON.

- Serilog uses what are called sinks to send your logs to different places such as a text file, database, or log management solutions, all without changing your code.
- The most popular of the standard sinks are the File and Console targets.


#### install Serilog
```sh
 # Syntax: 
         dotnet add [<PROJECT>] package <PACKAGE_NAME>
# Example   
## for console application
  dotnet add  package Serilog
  dotnet add  package Serilog.Sinks.Console
## for Asp.NetCore application
      dotnet add package Serilog.AspNetCore 
      dotnet add package  Microsoft.AspNetCore.Hosting
      dotnet add package Microsoft.Extensions.Hosting.Abstractions
      dotnet add package  Microsoft.Extensions.Hosting
```

- Log.Logger is configured to enrich log events with contextual information and write them to the console.    
-  The UseSerilog() method is added to the HostBuilder to replace the default .NET logger with Serilog.    
-  You can also configure Serilog to write logs to a file or a database by adding more sinks.  
  -  For example, to write logs to a file, you can use the WriteTo.File("log.txt") method.  


 - Log.Information method is used to log informational messages.
 - Log.Fatal method is used to log fatal errors.
 - Log.CloseAndFlush method is called at the end to ensure that all log events are flushed to the sink.
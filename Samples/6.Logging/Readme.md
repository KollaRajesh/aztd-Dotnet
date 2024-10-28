>  The **Microsoft.Extensions.Logging framework** is a flexible and extensible logging system used in .NET applications. 

Here are some of its uses:

1. *Structured Logging*: It supports high-performance, structured logging via the ILogger API to help monitor application behavior and diagnose issues.

2. *Multiple Destinations*: Logs can be written to different destinations by configuring different logging providers.

3. *Severity Levels*: The log level indicates the severity of the logged event and is used to filter out less important log messages.

4. *Integration with Hosts and Dependency Injection*: If your application is using Dependency Injection (DI) or a host such as ASP.NET’s WebApplication or Generic Host, then you should use ILoggerFactory and ILogger objects from their respective DI containers rather than creating them directly.

5. *Support for Third-Party Logging Frameworks*: Microsoft.Extensions.Logging offers a relatively simple mechanism for adding further logging “providers” and third-party logging frameworks such as NLog, log4net, and Serilog.

6. *Unit Testing Support*: Microsoft.Extensions.Logging is used for dependency injection, which is handy for unit testing.

7. *Cross-Platform Compatibility*: The code can be used not only in .NET Core on Windows and Linux, but in the full .NET framework too, giving the ability to standardize your instrumentation code across .NET and .NET Core.

#### install Microsoft.Extensions.Logging

```sh
 # Syntax: 
         dotnet add [<PROJECT>] package <PACKAGE_NAME>
# Example   
## for console application
  dotnet add package Microsoft.Extensions.Logging
  dotnet add package Microsoft.Extensions.Logging.Console
## for Asp.NetCore application

```

 - An ILoggerFactory is created using the LoggerFactory.Create method.
 - The AddConsole method configures the console logging provider so that log messages are written to the console.
 - An ILogger is created with a category named Program. The category is a string that is associated with each log message logged by the ILogger object. It’s used to group log messages from the same class (or category) together when searching or filtering logs.
- The LogInformation method is used to log a message at the Information level. The log level indicates the severity of the logged event and is used to filter out less important log messages.


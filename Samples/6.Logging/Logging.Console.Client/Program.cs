
using System.Globalization;
// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
 using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogInformation("Logging is {Description}.", "started");
  //logger.Log(LogLevel.Information,"Logging is {Description}.", "started");  //another way
   
    logger.LogError("Error occured at {Description}.", DateTime.Now);
    //logger.Log(LogLevel.Error,"Error occured at {Description}.", DateTime.Now); //another way
    
    logger.LogWarning("Logging will be goint to {Description}.", "end");
  //logger.Log(LogLevel.Warning,"Logging will be goint to {Description}.", "end"); //another way
    logger.LogInformation("Logging is {Description}.", "end");
// logger.Log(LogLevel.Information,"Logging is {Description}.", "end"); //another way


using System.Globalization;
using System.Reflection;

// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

//var EnvironmentName= Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.Machine);
//var EnvironmentName= Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.User);
var EnvironmentName = Environment.GetEnvironmentVariable("Environment")??string.Empty;
EnvironmentName.Display();
EnvironmentName.Display(nameof(EnvironmentName));
EnvironmentName.Display(()=>EnvironmentName);

> ### Overview of dotnet utility

> 1. Create solution file

```sh
 # Syntax:
   # dotnet new sln -o <Path of the solution file>
 
  #Example
   dotnet new sln 
```
> 2. How to create Console Project file
```sh
  # Syntax: 
   # dotnet new console  -o <Path of the project file>
  
   # Example
      dotnet new console -o Console.Client
      dotnet new classlib -o DTO
      dotnet new classlib -o DTO.Interfaces
      dotnet new classlib -o Extensions
      dotnet new web -o Web.Client
 ```  
>   2.1 How to create new file in project directory

```powershell 
    cd .\Console.Client\
    new-item  -n test.cs
``` 
> 3. How to add project file to Solution file 

```sh  
  #Syntax: dotnet sln <path-to-solution-file> add <path-to-project-file> 
    cd ..
    dotnet sln .\1.OverviewOfDotnetUtility.sln add .\Console.Client\Console.Client.csproj
    dotnet sln .\1.OverviewOfDotnetUtility.sln add .\DTO\DTO.csproj 
    dotnet sln .\1.OverviewOfDotnetUtility.sln add .\DTO.Interfaces\DTO.Interfaces.csproj
    dotnet sln .\1.OverviewOfDotnetUtility.sln add .\Extensions\Extensions.csproj
    dotnet sln .\1.OverviewOfDotnetUtility.sln add .\Web.Client\Web.Client.csproj
```
> 4. How to add project reference

```sh 
    # Syntax: 
       #dotnet add <path-to-csproj-file> reference <path-to-referenced-project-csproj-file>
     
    # Example
       dotnet add .\DTO\DTO.csproj  reference .\DTO.Interfaces\DTO.Interfaces.csproj
       dotnet add .\Console.Client\Console.Client.csproj  reference .\DTO\DTO.csproj
       dotnet add .\Console.Client\Console.Client.csproj  reference .\DTO.Interfaces\DTO.Interfaces.csproj
       dotnet add .\Console.Client\Console.Client.csproj  reference .\Extensions\Extensions.csproj

       dotnet add .\Web.Client\Web.Client.csproj  reference .\DTO\DTO.csproj
       dotnet add .\Web.Client\Web.Client.csproj  reference .\DTO.Interfaces\DTO.Interfaces.csproj
       dotnet add .\Web.Client\Web.Client.csproj  reference .\Extensions\Extensions.csproj

```
 > 5. How to add package reference 
 
 ```sh
    # Syntax: 
       dotnet add [<PROJECT>] package <PACKAGE_NAME>
     # Example   
       dotnet add  .\Console.Client\Console.Client.csproj  package Microsoft.Extensions.Configuration      
        #  dotnet add package Microsoft.Extensions.Configuration # ( if you are in the project directory )
        cd  .\Console.Client
       dotnet add  package Microsoft.Extensions.Configuration.Json  
       dotnet add package Microsoft.Extensions.Configuration.Binder
       dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```
> 6. Build Project\Solution using dotnet cli

```sh
# Syntax:
 dotnet build [<PROJECT | SOLUTION>...] [options]

#Example: (build project)
 dotnet build  .\Console.Client\Console.Client.csproj

#Example: (build solution) 

 dotnet build .\1.OverviewOfDotnetUtility.sln

```

> 7. Run Project using dotnet cli 

```sh
# Syntax:
dotnet run  --project [<PROJECT] [options]

#Example:
dotnet run  --project .\Console.Client\Console.Client.csproj
```

> For debugging dotnet app in VS code  (Note:  it is not required if do it from Visual studio IDE),
  
 - You need to add launch.json file tasks.json 
 
 Here are the steps :
 
  1. Open your .NET Core solution file in Visual Studio Code.
  2. Open the Debug view by clicking on the Debug icon in the left-hand menu.
  3. Create the launch.json file.
  4. In the launch.json file, add the following configuration:

```json
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": ".NET Core Launch (console)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "${workspaceFolder}/<path-to-your-console-project>/bin/Debug/net<version>/<your-console-project>.dll",
            "args": [],
            "cwd": "${workspaceFolder}/<path-to-your-project>",
            "console": "integratedTerminal",
            "stopAtEntry": false
        },
        ,
        {
            "name": ".NET Core Launch (web)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "${workspaceFolder}/<path-to-your-web-project>/bin/Debug/net<version>/<your-web-project>.dll",
            "args": [],
            "cwd": "${workspaceFolder}",
            "stopAtEntry": false,
            "serverReadyAction": {
                "action": "openExternally",
                "pattern": "^\\s*Now listening on:\\s+(https?://\\S+)"
            },
            "env": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            },
            "sourceFileMap": {
                "/Views": "${workspaceFolder}/Views"
            }
        }
    ]
}
```
  5. Replace <path-to-your-project> and <your-project> with the appropriate values for your project.
  6. Save the launch.json file.

> To add prebuild and build tasks to your project, you can follow these steps:

   1. Open the command prompt or terminal and navigate to the directory where your project is located.
   2. Type the following command to create a new tasks.json file:
   3. Open the tasks.json file and add the following tasks:
```json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "prebuild",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "<path-to-your-project>/<your-project>.csproj",
                "/t:prebuild",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "build",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "<path-to-your-project>/<your-project>.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        }
    ]
}
```
4. Replace <path-to-your-project> and <your-project> with the appropriate values for your project.
5. Save the tasks.json file.
 
You can now use the prebuild and build tasks to build your project and create the launch.json file.




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
      dotnet new console -o Console.UserSecrets.Client
      dotnet new classlib -o DTO
 ```  
> 3. How to add project file to Solution file 

```sh  
  #Syntax: dotnet sln <path-to-solution-file> add <path-to-project-file> 
   dotnet sln .\2.ManageUserSecrets.sln add .\Console.UserSecrets.Client\Console.UserSecrets.Client.csproj
```

> 4. How to add project reference

```sh 
    # Syntax: 
       #dotnet add <path-to-csproj-file> reference <path-to-referenced-project-csproj-file>
     
    # Example
       dotnet add .\Console.UserSecrets.Client\Console.UserSecrets.Client.csproj  reference .\DTO\DTO.csproj
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
        ## install below package to add user Secrets to Configuration Builder
        dotnet add package Microsoft.Extensions.Configuration.UserSecrets
        ## install below package to Add Environment variables to Configuration Builder
        dotnet add package  Microsoft.Extensions.Configuration.EnvironmentVariables
```
> 6. Build Project\Solution using dotnet cli

```sh
# Syntax:
 dotnet build [<PROJECT | SOLUTION>...] [options]

#Example: (build project)
 dotnet build  .\Console.Client\Console.Client.csproj

#Example: (build solution) 

 dotnet build .\TestSolution.sln

```

> 7. Run Project using dotnet cli 

```sh
# Syntax:
dotnet run  --project [<PROJECT] [options]

#Example:
dotnet run  --project .\Console.Client\Console.Client.csproj
```

> The order of precedence for configuration settings in ASP.NET Core is as follows:

  - appsettings.json: This is the base configuration file and is loaded first.
  - appsettings.{Environment}.json: This file is loaded next and is environment-specific.
         For example, appsettings.Development.json for the Development environment.
  - User Secrets: This is only loaded in the local development environment.
  - Environment Variables: These are loaded next and can override values from the previous files.

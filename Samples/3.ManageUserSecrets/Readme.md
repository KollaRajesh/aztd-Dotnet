> ### Overview of User Secrets in .NET Core

In .NET Core, User Secrets is a secure way of storing private user information such as API keys, client secrets, and connection strings.

-  Essentially anything that you don’t want others to know about when using your code base.  
-   The user secrets are not uploaded to any source control. This ensures your keys do in fact stay “secret” to your local machine. 

- The User Secrets is not a feature of .NET Core itself, but rather a NuGet package that can be added to your project.
- Once added, you can use the dotnet user-secrets command-line tool to manage your secrets.

Here are the steps to use User Secrets in your .NET Core app:

1. Install the Microsoft.Extensions.Configuration.UserSecrets NuGet package.
2. Right-click on your project in Visual Studio and select “Manage User Secrets”.
3. This will open the secrets.json file where you can add your secrets.
4. In your code, you can access the secrets using the IConfiguration interface.
 


 **Initialize user secrets**: To initialize user secrets for your project, run the following command in the project directory:

```sh 
dotnet user-secrets init
```
   This will create a secrets.json file in the user profile directory.

**Add a secret**: To add a secret to the user secrets store, run the following command:

```sh 
dotnet user-secrets set "MySecret" "MyValue"
```
This will add a secret with the key MySecret and value MyValue to the user secrets store.

***List all secrets***: To list all secrets in the user secrets store, run the following command:

```sh 
dotnet user-secrets list
```

**Remove a secret**: To remove a secret from the user secrets store, run the following command:

```sh 
dotnet user-secrets remove "MySecret"
```
 
 - **VS Code Extension**
  we can easily manage user secrets using [.NET Core User Secrets](https://marketplace.visualstudio.com/items?itemName=adrianwilczynski.user-secrets) Extension.

```cs
var EnvironmentName = Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.User)??string.Empty;

 var builder = new ConfigurationBuilder();
if (IsDevelopment(EnvironmentName))
{
 builder.AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true,reloadOnChange: true)
          .AddUserSecrets(Assembly.GetExecutingAssembly());
        //builder.AddUserSecrets<Program>();
}

Console.WriteLine(configuration.GetValue<string>("UserKey1"));
```
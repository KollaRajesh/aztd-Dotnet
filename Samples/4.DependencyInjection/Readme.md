> Overview of Dependency Injection (DI) in .NET Core 

**Dependency injection (DI)** is a programming technique that aims to decouple objects from their dependencies.  

 - It is a design pattern that allows objects to define their dependencies only through constructor arguments, arguments to a factory method, or properties that are set on the object instance after it is constructed or returned from a factory method.  

- In simpler terms, DI is a way to manage the dependencies between objects in an application and to provide a way to create and manage object instances

**Microsoft.Extensions.DependencyInjection** is a NuGet package that provides a lightweight dependency injection (DI) container for .NET applications. It is used to manage the dependencies between objects in an application and to provide a way to create and manage object instances.

 ```sh
    # Syntax: 
         dotnet add [<PROJECT>] package <PACKAGE_NAME>
     # Example   
        cd  .\DI.Console.Client

        dotnet add package Microsoft.Extensions.DependencyInjection  
```

- The DI container is managed by adding services and configuring them in an *IServiceCollection*. The IHost interface exposes the *IServiceProvider* instance, which acts as a container of all the registered services.


    **ServiceCollection** is a class in the Microsoft.Extensions.DependencyInjection namespace that provides a lightweight dependency injection (DI) container for .NET applications. Here are some of the methods available in the ServiceCollection class:

       1. *AddSingleton*: Adds a singleton service to the DI container. A singleton service is created only once and is shared by all consumers of the service.

       2. *AddTransient*: Adds a transient service to the DI container. A transient service is created each time it is requested.

       3. *AddScoped*: Adds a scoped service to the DI container. A scoped service is created once per request.

       4. *BuildServiceProvider*: Builds the DI container and returns an IServiceProvider instance.

       5. *Clear*: Removes all services from the DI container.

       6. *Contains*: Determines whether a service is registered in the DI container.

       7. *Remove*: Removes a service from the DI container.

       8. *Count*: Gets the number of services registered in the DI container.

       9. *GetEnumerator*: Returns an enumerator that iterates through the services registered in the DI container.

```cs 
     var serviceProvider = new ServiceCollection()
                .AddSingleton<IMyDependency, MyDependency>()
                .BuildServiceProvider();

            var myDependency = serviceProvider.GetService<IMyDependency>()
```
Here are some use cases of Microsoft.Extensions.DependencyInjection:

  1. **Web applications**: DI is commonly used in web applications to manage dependencies between controllers, services, and repositories. Microsoft.Extensions.DependencyInjection can be used to register services and configure the DI container in an *IServiceCollection*.

  2. **Console applications**: DI can also be used in console applications to manage dependencies between objects. Microsoft.Extensions.DependencyInjection can be used to register services and configure the DI container in an *IServiceCollection*.

  3. **Unit testing**: DI can beused to inject mock objects into unit tests. Microsoft.Extensions.DependencyInjection can be used to register mock objects and configure the DI container in an *IServiceCollection*.

  4. **Windows services**: DI can be used in Windows services to manage dependencies between objects. Microsoft.Extensions.DependencyInjection can be used to register services and configure the DI container in an *IServiceCollection*.


> Note:  The Service Locator pattern is not recommended in ASP.NET Core.  

   - Instead, you should use dependency injection (DI) to resolve dependencies.   
   - DI is a design pattern that allows you to manage the dependencies between objects in an application and to provide a way to create and manage object instances. 
   - If you need to access a service in a method, you can inject the IServiceProvider interface into the constructor of your class and use it to resolve the service
    
   ```cs
   using Microsoft.Extensions.DependencyInjection;
   
   public class PersonRepository{
        public PersonRepository(IServiceProvider  serviceProvider )
        {
                var config = serviceProvider.GetService<IConfiguration>();
                _connectionString = config.GetConnectionString("DefaultConnection");
        }
     }
     ```
// See https://aka.ms/new-console-template for more information
using System;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
 Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        //.WriteTo.File("log.txt")
        .CreateLogger();

    try
    {
        Log.Information("Starting up");
       // CreateHostBuilder(args).Build().Run();
       Log.Information("Application ended successfully");
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Application start-up failed");
        //return 1;
    }
    finally
    {
        Log.CloseAndFlush();
    }

 static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        //.UseSerilog() // <-- Add this line
        .ConfigureWebHostDefaults(webBuilder =>
        {
            //webBuilder.UseStartup<Startup>();
            //instead of using Startup class , build configure services and configure methods
            //using lambda function   
            webBuilder.ConfigureServices(services =>
            {
                // Add your services here
            })
            .Configure(app =>
            {
                // Configure your middleware here
            // if (!app.Environment.IsDevelopment())
            //     {
            //         app.UseExceptionHandler("/Error");
            //         app.UseHsts();
            //     }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

      
                       
            });
        });

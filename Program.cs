using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
var basePath = System.IO.Path.GetDirectoryName(location);
var dotnetEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");


if (basePath != null)
{

    var configurationBuilder = new ConfigurationBuilder();
    configurationBuilder.SetBasePath(basePath);
    configurationBuilder.AddEnvironmentVariables("MYAPP_");
    configurationBuilder.AddJsonFile(String.IsNullOrEmpty(dotnetEnvironment) ? "appsettings.json" : $"appsettings.{dotnetEnvironment}.json");
    var config = configurationBuilder.Build();

    var serviceProvider = new ServiceCollection();
    serviceProvider.AddSingleton<IConfiguration>(config);


}
else
{
    Console.Error.WriteLine("Unable to get the current location of the assembly");
    System.Environment.Exit(1);
}








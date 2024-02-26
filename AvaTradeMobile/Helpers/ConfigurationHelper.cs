using Microsoft.Extensions.Configuration;

namespace AvaTradeMobile.Helpers;

public class ConfigurationHelper
{
    public static IConfiguration Config;
    public static void InitializeConfiguration()
    {
        var envName = "test";
        var builder = new ConfigurationBuilder().
            SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("application.json");
            // .AddJsonFile($"application.{envName}.json", optional: true);
        Config = builder.Build();
    }

}

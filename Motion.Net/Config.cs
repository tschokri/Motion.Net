using Microsoft.Extensions.Configuration;

namespace Motion.Net;

public abstract class Config
{
    private static readonly IConfiguration Configuration = new ConfigurationBuilder()
        .SetBasePath(Path.GetFullPath(@"..\..\..\"))
        .AddJsonFile("appsettings.json", false, true)
        .Build();

    public static string? GetVariable(string name)
    {
        return Configuration[$"AppSettings:{name}"];
    }
}
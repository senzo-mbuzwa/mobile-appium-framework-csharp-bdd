using Microsoft.Extensions.Configuration;

namespace MobileAppiumFramework.Utilities;

/// <summary>
/// Centralized configuration reader for the framework.
/// 
/// Responsible for:
/// - Loading appsettings.json
/// - Providing access to configuration values
/// 
/// Usage:
/// string serverUrl = ConfigReader.Get("Appium:ServerUrl");
/// </summary>
public static class ConfigReader
{
    // Holds the loaded configuration from appsettings.json
    private static readonly IConfigurationRoot Config;

    /// <summary>
    /// Static constructor runs once when the class is first used.
    /// Loads configuration from the Config/appsettings.json file.
    /// </summary>
    static ConfigReader()
    {
        Config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Config/appsettings.json", optional: false)
            .Build();
    }

    /// <summary>
    /// Retrieves a configuration value by key.
    /// 
    /// Example:
    /// ConfigReader.Get("Appium:DeviceName")
    /// </summary>
    /// <param name="key">Configuration key</param>
    /// <returns>Configuration value</returns>
    /// <exception cref="Exception">Thrown when key is missing</exception>
    public static string Get(string key)
    {
        return Config[key]
            ?? throw new Exception($"Config key not found: {key}");
    }
}
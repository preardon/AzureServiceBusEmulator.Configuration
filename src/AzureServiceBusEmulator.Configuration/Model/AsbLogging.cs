namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// The Logging Type
/// </summary>
/// <param name="Type">The Logging type</param>
public record AsbLogging(string Type = "File");
namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// The Asb Emulator Configuration
/// </summary>
/// <param name="Namespaces">The Namesspaces in the Confiugration</param>
/// <param name="Logging">The Logging Configuration</param>
public record UserConfig(AsbNamespace[] Namespaces, AsbLogging Logging);
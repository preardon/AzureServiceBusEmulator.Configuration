namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// ASB Queue Configuration
/// </summary>
/// <param name="Name">The Queue Name</param>
/// <param name="Properties">The Queues Properties</param>
public record AsbQueue(string Name, AsbChannelProperties Properties);
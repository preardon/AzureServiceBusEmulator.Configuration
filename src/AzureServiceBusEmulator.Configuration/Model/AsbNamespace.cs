namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// ASB Namespace configuration
/// </summary>
/// <param name="Name">Name of ASB Namespace</param>
/// <param name="Queues">The Queues in the Namespace</param>
/// <param name="Topics">The Topics in the Namespace</param>
public record AsbNamespace(string Name, AsbQueue[] Queues, AsbTopic[] Topics);
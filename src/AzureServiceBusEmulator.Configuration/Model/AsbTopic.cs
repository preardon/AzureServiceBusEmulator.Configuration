namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// ASB Topic Configuration
/// </summary>
/// <param name="Name">The name of the Topic</param>
/// <param name="Properties">The Properties of the Topic</param>
/// <param name="Subscriptions">The subscription under the Topic</param>
public record AsbTopic(string Name, AsbTopicProperties Properties, AsbSubscription[] Subscriptions);
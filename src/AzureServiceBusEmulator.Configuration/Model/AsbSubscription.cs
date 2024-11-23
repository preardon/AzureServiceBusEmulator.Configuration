namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// Configuration for an Azure Service Bus emulator Rule
/// </summary>
/// <param name="Name">Subscription name</param>
/// <param name="Properties">Subscription Properties</param>
/// <param name="Rules">Rules</param>
public record AsbSubscription(string Name, AsbChannelProperties Properties, AsbSubscriptionRules[] Rules);
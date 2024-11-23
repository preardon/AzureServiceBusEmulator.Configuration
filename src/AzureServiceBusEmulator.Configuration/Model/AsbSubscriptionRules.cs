namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// Azure Service Bus Subscription Rule Properties
/// </summary>
/// <param name="Name">Name of Rule</param>
/// <param name="Properties">Rule Properties</param>
public record AsbSubscriptionRules(string Name, AsbRuleProperties Properties);
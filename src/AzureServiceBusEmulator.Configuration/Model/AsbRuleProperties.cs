namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// Azure Service Bus Subscription Rule Properties Configuration
/// </summary>
/// <param name="CorrelationFilter">Correlation Filter Rules</param>
/// <param name="FilterType">Type of Fitler (default: 'Correlation')</param>
public record AsbRuleProperties(AsbRulePropertiesCorrelationFilter CorrelationFilter, string FilterType = "Correlation");
using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration.Builders;

/// <summary>
/// Builder for ASB Subscription Configuartion 
/// </summary>
/// <param name="name">Subscription Name</param>
public class AsbSubscriptionBuilder(string name)
{
    private readonly List<AsbSubscriptionRules> _rules = [];
    private AsbChannelProperties _asbChannelProperties = new();
    
    /// <summary>
    /// Include a Rule in the configuration for this Subscription
    /// </summary>
    /// <param name="ruleName">The rule name</param>
    /// <param name="filterType">The filter type for the rule</param>
    /// <param name="options">The configuration for the Rule</param>
    /// <returns>ASB Subscription Builder</returns>
    public AsbSubscriptionBuilder WithRule(string ruleName, string filterType = "Correlation", Action<AsbSubscriptionRulesBuilder>? options = null)
    {
        var builder = new AsbSubscriptionRulesBuilder(ruleName, filterType);
        options?.Invoke(builder);
        _rules.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Configuration Subscription Properties
    /// </summary>
    /// <param name="subscriptionPropertiesBuilder"></param>
    /// <returns>ASB Subscription Builder</returns>
    public AsbSubscriptionBuilder WithProperties(Action<AsbSubscriptionPropertiesBuilder> subscriptionPropertiesBuilder)
    {
        var builder = new AsbSubscriptionPropertiesBuilder();
        subscriptionPropertiesBuilder.Invoke(builder);
        _asbChannelProperties = builder.Build();
        return this;
    }
    
    public AsbSubscription Build() => new AsbSubscription(name, _asbChannelProperties, _rules.ToArray());
}
using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration.Builders;

/// <summary>
/// Topic Configuration Builder
/// </summary>
/// <param name="name">The name of the Topic</param>
public class AsbTopicBuilder(string name)
{
    private List<AsbSubscription> _subscriptions = new();
    private AsbTopicProperties _properties = new();
    
    /// <summary>
    /// Add an ASB subscription to the Topic
    /// </summary>
    /// <param name="subscriptionName">Name of the Subscription</param>
    /// <param name="subscriptionOptions">Configurtion the options of the subscription</param>
    /// <returns>ASB Topic builder</returns>
    public AsbTopicBuilder WithSubscription(string subscriptionName, Action<AsbSubscriptionBuilder>? subscriptionOptions = null)
    {
        var subscriptionsBuilder = new AsbSubscriptionBuilder(subscriptionName);
        subscriptionOptions?.Invoke(subscriptionsBuilder);
        _subscriptions.Add(subscriptionsBuilder.Build());
        return this;
    }

    /// <summary>
    /// Configure Topic properties
    /// </summary>
    /// <param name="topicPropertiesOptions">Set the properties of a Topic</param>
    /// <returns>ASB Topic builder</returns>
    public AsbTopicBuilder WithTopicProperties(Action<AsbTopicPropertiesBuilder> topicPropertiesOptions)
    {
        var builder = new AsbTopicPropertiesBuilder();
        topicPropertiesOptions.Invoke(builder);
        _properties = builder.Build();
        return this;
    }
    
    /// <summary>
    /// Build Topic
    /// </summary>
    /// <returns>ASB Topic Configuration</returns>
    public AsbTopic Build() => new AsbTopic(name, _properties, _subscriptions.ToArray());
}
using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration.Builders;

/// <summary>
/// The Namespace Builder
/// </summary>
/// <param name="name">The name of the namespace</param>
public class AsbNamespaceBuilder(string name)
{
    private readonly List<AsbQueue> _queues = [];
    private readonly List<AsbTopic> _topics = [];

    public static AsbNamespaceBuilder WithName(string name) => new AsbNamespaceBuilder(name);

    /// <summary>
    /// Add a queue to the configuration
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="queueOptions"></param>
    /// <returns></returns>
    public AsbNamespaceBuilder WithQueue(string queueName, Action<AsbQueueBuilder>? queueOptions = null)
    {
        var builder = new AsbQueueBuilder(queueName);
        queueOptions?.Invoke(builder);
        _queues.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Add a Topic to the configuration
    /// </summary>
    /// <param name="topicName"></param>
    /// <param name="topicOptions"></param>
    /// <returns></returns>
    public AsbNamespaceBuilder WithTopic(string topicName, Action<AsbTopicBuilder>? topicOptions = null)
    {
        var builder = new AsbTopicBuilder(topicName);
        topicOptions?.Invoke(builder);
        _topics.Add(builder.Build());
        return this;
    }
    public AsbNamespace Build() => new AsbNamespace(name, _queues.ToArray(), _topics.ToArray());
}
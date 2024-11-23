using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration.Builders;

/// <summary>
/// Builder for an ASB Queue
/// </summary>
/// <param name="name"></param>
public class AsbQueueBuilder(string name)
{
    private bool _deadLetteringOnMessageExpiration = false;
    private string _defaultMessageTimeToLive = "PT1H";
    private string _duplicateDetectionHistoryTimeWindow = "PT20S";
    private string _forwardDeadLetteredMessagesTo = "";
    private string _forwardTo = "";
    private string _lockDuration = "PT1M";
    private int _maxDeliveryCount = 3;
    private bool _requiresDuplicateDetection = false;
    private bool _requiresSession = false;
    
    /// <summary>
    /// Enable Dead lettering on Message Expiration
    /// </summary>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder DeadLetteringOnMessageExpiration(bool deadLetteringOnMessageExpiration = true)
    {
        _deadLetteringOnMessageExpiration = deadLetteringOnMessageExpiration;
        return this;
    }

    /// <summary>
    /// Require the use of AsbSessions
    /// </summary>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder RequireSessions(bool requireSession = true)
    {
        _requiresSession = requireSession;
        return this;
    }

    /// <summary>
    /// The default amount of time before the message is removed from the queue
    /// </summary>
    /// <param name="defaultMessageTimeToLive">The default amount of time before the message is removed from the queue.</param>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder DefaultMessageTimeToLive(string defaultMessageTimeToLive = "PT1H")
    {
        _defaultMessageTimeToLive = defaultMessageTimeToLive;
        return this;
    }

    /// <summary>
    /// Detect duplicate messages inside of this time window
    /// </summary>
    /// <param name="duplicateDetectionHistoryTimeWindow"></param>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder DuplicateDetectionHistoryTimeWindow(string duplicateDetectionHistoryTimeWindow = "PT20S")
    {
        _duplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryTimeWindow;
        return this;
    }

    /// <summary>
    /// Set a queue to forward dead letters to
    /// </summary>
    /// <param name="forwardDeadLetteredMessagesTo">Queue to forward dead letters to</param>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder ForwardDeadLetteredMessagesTo(string forwardDeadLetteredMessagesTo)
    {
        _forwardDeadLetteredMessagesTo = forwardDeadLetteredMessagesTo;
        return this;
    }

    /// <summary>
    /// Queue to forward messags to
    /// </summary>
    /// <param name="forwardTo"></param>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder ForwardTo(string forwardTo)
    {
        _forwardTo = forwardTo;
        return this;
    }

    /// <summary>
    /// The amount of time before a lock expires
    /// </summary>
    /// <param name="lockDuration"></param>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder LockDuration(string lockDuration = "PT1M")
    {
        _lockDuration = lockDuration;
        return this;
    }

    /// <summary>
    /// The maximum redelivers before the message is removed form the queue
    /// </summary>
    /// <param name="maxDeliveryCount"></param>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder MaxDeliveryCount(int maxDeliveryCount)
    {
        _maxDeliveryCount = maxDeliveryCount;
        return this;
    }

    /// <summary>
    /// Does the queue require duplication detection
    /// </summary>
    /// <param name="requiresDuplicateDetection">does the queue require duplication detection</param>
    /// <returns>ASB Queue Builder</returns>
    public AsbQueueBuilder RequiresDuplicateDetection(bool requiresDuplicateDetection = true)
    {
        _requiresDuplicateDetection = requiresDuplicateDetection;
        return this;
    }

    /// <summary>
    /// Build the Queue
    /// </summary>
    /// <returns>ASB Queue Configuration</returns>
    public AsbQueue Build() => new AsbQueue(name,
        new AsbChannelProperties(_deadLetteringOnMessageExpiration, _defaultMessageTimeToLive,
            _duplicateDetectionHistoryTimeWindow, _forwardDeadLetteredMessagesTo, _forwardTo, _lockDuration,
            _maxDeliveryCount, _requiresDuplicateDetection, _requiresSession));
}
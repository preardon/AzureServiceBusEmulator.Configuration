using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration.Builders;

/// <summary>
/// Configuration for Subscription properties
/// </summary>
public class AsbSubscriptionPropertiesBuilder()
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
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder DeadLetteringOnMessageExpiration(bool deadLetteringOnMessageExpiration = true)
    {
        _deadLetteringOnMessageExpiration = deadLetteringOnMessageExpiration;
        return this;
    }

    /// <summary>
    /// Require the use of AsbSessions
    /// </summary>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder RequireSessions(bool requireSession = true)
    {
        _requiresSession = requireSession;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="defaultMessageTimeToLive">The default amount of time before the message is removed from the queue.</param>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder DefaultMessageTimeToLive(string defaultMessageTimeToLive = "PT1H")
    {
        _defaultMessageTimeToLive = defaultMessageTimeToLive;
        return this;
    }

    /// <summary>
    /// Detect duplicate messages inside of this time window
    /// </summary>
    /// <param name="duplicateDetectionHistoryTimeWindow"></param>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder DuplicateDetectionHistoryTimeWindow(string duplicateDetectionHistoryTimeWindow = "PT20S")
    {
        _duplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryTimeWindow;
        return this;
    }

    /// <summary>
    /// Set a queue to forward dead letters to
    /// </summary>
    /// <param name="forwardDeadLetteredMessagesTo">Queue to forward dead letters to</param>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder ForwardDeadLetteredMessagesTo(string forwardDeadLetteredMessagesTo)
    {
        _forwardDeadLetteredMessagesTo = forwardDeadLetteredMessagesTo;
        return this;
    }

    /// <summary>
    /// Queue to forward messags to
    /// </summary>
    /// <param name="forwardTo"></param>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder ForwardTo(string forwardTo)
    {
        _forwardTo = forwardTo;
        return this;
    }

    /// <summary>
    /// The amount of time before a lock expires
    /// </summary>
    /// <param name="lockDuration"></param>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder LockDuration(string lockDuration = "PT1M")
    {
        _lockDuration = lockDuration;
        return this;
    }

    /// <summary>
    /// The maximum redelivers before the message is removed form the subscription
    /// </summary>
    /// <param name="maxDeliveryCount"></param>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder MaxDeliveryCount(int maxDeliveryCount)
    {
        _maxDeliveryCount = maxDeliveryCount;
        return this;
    }

    /// <summary>
    /// Does the subscription require duplication detection
    /// </summary>
    /// <param name="requiresDuplicateDetection">does the subscription require duplication detection</param>
    /// <returns>ASB Subscription Properties Builder</returns>
    public AsbSubscriptionPropertiesBuilder RequiresDuplicateDetection(bool requiresDuplicateDetection = true)
    {
        _requiresDuplicateDetection = requiresDuplicateDetection;
        return this;
    }

    /// <summary>
    /// Build 
    /// </summary>
    /// <returns>AsbChannelProperties</returns>
    public AsbChannelProperties Build() => new AsbChannelProperties(_deadLetteringOnMessageExpiration,
        _defaultMessageTimeToLive, _duplicateDetectionHistoryTimeWindow, _forwardDeadLetteredMessagesTo, _forwardTo,
        _lockDuration, _maxDeliveryCount, _requiresDuplicateDetection, _requiresSession);
}
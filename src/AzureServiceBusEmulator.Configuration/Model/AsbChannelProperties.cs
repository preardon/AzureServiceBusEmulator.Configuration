namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;


/// <summary>
/// Asb Channel Property Configuration
/// </summary>
/// <param name="DeadLetteringOnMessageExpiration">Send the message to the dead-letter queue when it expires</param>
/// <param name="DefaultMessageTimeToLive">The amount of time a message can live before it is expired</param>
/// <param name="DuplicateDetectionHistoryTimeWindow">The time-window in which to check for duplicate messages</param>
/// <param name="ForwardDeadLetteredMessagesTo">Which Queue to send dead letters to</param>
/// <param name="ForwardTo">Where to forward messages to</param>
/// <param name="LockDuration">The time before a lock taken out on a message expires</param>
/// <param name="MaxDeliveryCount">The Maximum amount of times that a message can be delivered before it expires.</param>
/// <param name="RequiresDuplicateDetection">Check for Duplication Detection</param>
/// <param name="RequiresSession">Enable Session on this Channel</param>
public record AsbChannelProperties(
    bool DeadLetteringOnMessageExpiration = false,
    string DefaultMessageTimeToLive = "PT1H",
    string DuplicateDetectionHistoryTimeWindow = "PT20S",
    string ForwardDeadLetteredMessagesTo = "",
    string ForwardTo = "",
    string LockDuration = "PT1M",
    int MaxDeliveryCount = 3,
    bool RequiresDuplicateDetection = false,
    bool RequiresSession = false);
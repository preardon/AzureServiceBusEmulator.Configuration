namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// ASB Topic Properties
/// </summary>
/// <param name="DefaultMessageTimeToLive">The amount of time before a message Expires (default: 'PT1H')</param>
/// <param name="DuplicateDetectionHistoryTimeWindow">The time-window in which to check for duplicate messages (default: 'PT20S')</param>
/// <param name="RequiresDuplicateDetection">Does this topic require the use of duplication detection (default: false)</param>
public record AsbTopicProperties(string DefaultMessageTimeToLive = "PT1H", 
    string DuplicateDetectionHistoryTimeWindow = "PT20S", 
    bool RequiresDuplicateDetection = false);
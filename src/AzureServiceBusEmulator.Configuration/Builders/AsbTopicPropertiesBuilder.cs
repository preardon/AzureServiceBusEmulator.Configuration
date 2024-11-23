using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration.Builders;

/// <summary>
/// Builder for the configuration of Topic Properties
/// </summary>
public class AsbTopicPropertiesBuilder
{
    private string _defaultMessageTimeToLive = "PT1H";
    private string _duplicateDetectionHistoryTimeWindow = "PT20S";
    private bool _requiresDuplicateDetection = false;

    /// <summary>
    /// Set the Default Messaging Time to live
    /// </summary>
    /// <param name="defaultMessageTimeToLive"></param>
    /// <returns>ASB Topic Property builder</returns>
    public AsbTopicPropertiesBuilder DefaultMessageTimeToLive(string defaultMessageTimeToLive = "PT1H")
    {
        _defaultMessageTimeToLive = defaultMessageTimeToLive;
        return this;
    }

    /// <summary>
    /// Set message duplication detection window
    /// </summary>
    /// <param name="duplicateDetectionHistoryTimeWindow">The time window in which to detect duplicate messages</param>
    /// <returns>ASB Topic Property builder</returns>
    public AsbTopicPropertiesBuilder DuplicateDetectionHistoryTimeWindow(string duplicateDetectionHistoryTimeWindow = "PT20S")
    {
        _duplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryTimeWindow;
        return this;
    }

    /// <summary>
    /// Set the default message Time to live
    /// </summary>
    /// <param name="requiresDuplicateDetection">Does this topic require duplication</param>
    /// <returns>ASB Topic Property builder</returns>
    public AsbTopicPropertiesBuilder RequiresDuplicateDetection(bool requiresDuplicateDetection = false)
    {
        _requiresDuplicateDetection = requiresDuplicateDetection;
        return this;
    }
    
    /// <summary>
    /// Build Topic Property configuration
    /// </summary>
    /// <returns>Topic Property Configuration</returns>
    public AsbTopicProperties Build() => new AsbTopicProperties(_defaultMessageTimeToLive,
        _duplicateDetectionHistoryTimeWindow, _requiresDuplicateDetection);
}
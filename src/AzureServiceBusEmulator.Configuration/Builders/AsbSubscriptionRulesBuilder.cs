using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration.Builders;

/// <summary>
/// Builder for ASB Subscription Rules
/// </summary>
/// <param name="name">Rule Name</param>
/// <param name="filterType">Filter Type</param>
public class AsbSubscriptionRulesBuilder(string name, string filterType)
{
    private string _contentType = "application/json";
    private string? _correlationId = null;
    private string? _label = null;
    private string? _messageId = null;
    private string? _replyTo = null;
    private string? _replyToSessionId = null;
    private string? _sessionId = null;
    private string? _to = null;

    /// <summary>
    /// Set the content Type
    /// </summary>
    /// <param name="contentType">The content type</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder ContentType(string contentType)
    {
        _contentType = contentType;
        return this;
    }
    
    /// <summary>
    /// Set the Correlation Id
    /// </summary>
    /// <param name="correlationId">The Correlation Id</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder CorrelationId(string correlationId)
    {
        _correlationId = correlationId;
        return this;
    }
    
    /// <summary>
    /// Set the Label
    /// </summary>
    /// <param name="label">The Label</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder Label(string label)
    {
        _label = label;
        return this;
    }
    
    /// <summary>
    /// Set the Message Id
    /// </summary>
    /// <param name="messageId">Message Id</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder MessageId(string messageId)
    {
        _messageId = messageId;
        return this;
    }
    
    /// <summary>
    /// Set the Reply To
    /// </summary>
    /// <param name="replyTo">The Reply To</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder ReplyTo(string replyTo)
    {
        _replyTo = replyTo;
        return this;
    }
    
    /// <summary>
    /// Set the Reply To Session Id
    /// </summary>
    /// <param name="replyToSessionId">Reply To Session Id</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder ReplyToSessionId(string replyToSessionId)
    {
        _replyToSessionId = replyToSessionId;
        return this;
    }
    
    /// <summary>
    /// Set the Session Id
    /// </summary>
    /// <param name="sessionId">Session Id</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder SessionId(string sessionId)
    {
        _sessionId = sessionId;
        return this;
    }
    
    /// <summary>
    /// Set To
    /// </summary>
    /// <param name="to">To</param>
    /// <returns>ASB Subscription Rule Builder</returns>
    public AsbSubscriptionRulesBuilder To(string to)
    {
        _to = to;
        return this;
    }
    
    /// <summary>
    /// Build Subscription Rule Configuration
    /// </summary>
    /// <returns>Asb Subscription Rule Configuration</returns>
    public AsbSubscriptionRules Build() => new AsbSubscriptionRules(name,
        new AsbRuleProperties(
            new AsbRulePropertiesCorrelationFilter(_contentType, _correlationId, _label, _messageId, _replyTo,
                _replyToSessionId, _sessionId, _to), filterType));
}
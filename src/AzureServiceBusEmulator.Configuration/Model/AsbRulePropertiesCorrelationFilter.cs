namespace ReardonTech.AzureServiceBusEmulator.Configuration.Model;

/// <summary>
/// Correlation Filter Configuration
/// </summary>
/// <param name="ContentType">Content type (default: 'application/json')</param>
/// <param name="CorrelationId">The Correlation Id</param>
/// <param name="Label">The Label</param>
/// <param name="MessageId">The Message Id</param>
/// <param name="ReplyTo">Where to send reply messages</param>
/// <param name="ReplyToSessionId">The Session Id to use for reply messages</param>
/// <param name="SessionId">The Session Id</param>
/// <param name="To">Where to send the message to</param>
public record AsbRulePropertiesCorrelationFilter(string ContentType = "application/json", 
    string? CorrelationId = null, 
    string? Label = null, 
    string? MessageId = null, 
    string? ReplyTo = null, 
    string? ReplyToSessionId = null, 
    string? SessionId = null, 
    string? To = null);
using ReardonTech.AzureServiceBusEmulator.Configuration;

namespace AzureServiceBusEmulator.Configuration.UnitTest;

[TestFixture]
public class ConfigurationBuilderTests
{

    [TestCase]
    public void GivenAConfigurationBuilder_WhenBuildIsCalled_AConfigurationItemIsProduced()
    {
        var namespaceName = "testNamespace";
        // queue Properties
        var queueName = "testQueue";
        var queuePropertyDeadLetteringOnMessageExpiration = true;
        var queuePropertyDefaultMessageTimeToLive = "PT2H";
        var queuePropertyDuplicateDetectionHistoryTimeWindow = "PT21S";
        var queuePropertyForwardDeadLetteredMessagesTo = "ForwardTopic";
        var queuePropertyForwardTo = "ForwarTo";
        var queuePropertyLockDuration = "PT2M";
        var queuePropertyMaxDeliveryCount = 7;
        var queuePropertyRequiresDuplicateDetection = true;
        var queuePropertyRequiresSession = true;
        
        // topic Properties
        var topicName = "testTopic";
        var topicPropertiesRequiresDuplicateDetection = true;
        var topicPropertiesDefaultMessageTimeToLive = "PT2H";
        var topicPropertiesDuplicateDetectionHistoryTimeWindow = "PT21S";
        
        // topic subscription
        var subscriptionName = "testSubscription";
        var subscriptionPropertyDeadLetteringOnMessageExpiration = true;
        var subscriptionPropertyDefaultMessageTimeToLive = "PT2H";
        var subscriptionPropertyDuplicateDetectionHistoryTimeWindow = "PT21S";
        var subscriptionPropertyForwardDeadLetteredMessagesTo = "ForwardTopic";
        var subscriptionPropertyForwardTo = "ForwarTo";
        var subscriptionPropertyLockDuration = "PT2M";
        var subscriptionPropertyMaxDeliveryCount = 7;
        var subscriptionPropertyRequiresDuplicateDetection = true;
        var subscriptionPropertyRequiresSession = true;
        var subscriptionRuleName = "testSubscriptionRule";
        var subscriptionRuleType = "TestType";
        var subscriptionRuleContentType = "application/xml";
        var subscriptionRuleCorrelationId = "7";
        var subscriptionRuleLabel = "ruleLabel";
        var subscriptionRuleMessageId = "27";
        var subscriptionRuleReplyTo = "OverThere";
        var subscriptionRuleReplyToSessionId = "99"; 
        var subscriptionRuleSessionId = "76";
        var subscriptionRuleTo = "You";

        var loggingType = "TestLogging";
        
        var builder = AsbEmulatorConfigurationBuilder.WithNamespace(namespaceName, n =>
        {
            n.WithQueue(queueName, qo =>
            {
                qo.RequireSessions()
                    .DeadLetteringOnMessageExpiration(queuePropertyDeadLetteringOnMessageExpiration)
                    .DefaultMessageTimeToLive(queuePropertyDefaultMessageTimeToLive)
                    .DuplicateDetectionHistoryTimeWindow(queuePropertyDuplicateDetectionHistoryTimeWindow)
                    .ForwardDeadLetteredMessagesTo(queuePropertyForwardDeadLetteredMessagesTo)
                    .ForwardTo(queuePropertyForwardTo)
                    .LockDuration(queuePropertyLockDuration)
                    .MaxDeliveryCount(queuePropertyMaxDeliveryCount)
                    .RequiresDuplicateDetection(queuePropertyRequiresDuplicateDetection)
                    .RequireSessions(queuePropertyRequiresSession);
            });
            n.WithTopic(topicName, to =>
            {
                to.WithTopicProperties(tp =>
                    tp.DefaultMessageTimeToLive(topicPropertiesDefaultMessageTimeToLive)
                        .DuplicateDetectionHistoryTimeWindow(topicPropertiesDuplicateDetectionHistoryTimeWindow)
                        .RequiresDuplicateDetection(topicPropertiesRequiresDuplicateDetection));
                
                to.WithSubscription(subscriptionName, so =>
                {
                    so.WithProperties(p => p
                        .DeadLetteringOnMessageExpiration(subscriptionPropertyDeadLetteringOnMessageExpiration)
                        .DefaultMessageTimeToLive(subscriptionPropertyDefaultMessageTimeToLive)
                        .DuplicateDetectionHistoryTimeWindow(subscriptionPropertyDuplicateDetectionHistoryTimeWindow)
                        .ForwardDeadLetteredMessagesTo(subscriptionPropertyForwardDeadLetteredMessagesTo)
                        .ForwardTo(subscriptionPropertyForwardTo)
                        .LockDuration(subscriptionPropertyLockDuration)
                        .MaxDeliveryCount(subscriptionPropertyMaxDeliveryCount)
                        .RequiresDuplicateDetection(subscriptionPropertyRequiresDuplicateDetection)
                        .RequireSessions(subscriptionPropertyRequiresSession));
                    so.WithRule(subscriptionRuleName, subscriptionRuleType, o => o
                        .ContentType(subscriptionRuleContentType)
                        .CorrelationId(subscriptionRuleCorrelationId)
                        .Label(subscriptionRuleLabel)
                        .MessageId(subscriptionRuleMessageId)
                        .ReplyTo(subscriptionRuleReplyTo)
                        .ReplyToSessionId(subscriptionRuleReplyToSessionId)
                        .SessionId(subscriptionRuleSessionId)
                        .To(subscriptionRuleTo));
                });
            });
        });

        builder.WithLogging(loggingType);
        
        var configuration = builder.Build();
        
        //Assert
        
        var configurationNamespace = configuration.UserConfig.Namespaces.Single(n => n.Name == namespaceName);
        Assert.That(configurationNamespace.Name, Is.EqualTo(namespaceName));
        
        // Queue
        var queue = configurationNamespace.Queues.Single(q => q.Name == queueName);
        Assert.That(queue.Name, Is.EqualTo(queueName));
        Assert.That(queue.Properties.DeadLetteringOnMessageExpiration, Is.EqualTo(queuePropertyDeadLetteringOnMessageExpiration));
        Assert.That(queue.Properties.DefaultMessageTimeToLive, Is.EqualTo(queuePropertyDefaultMessageTimeToLive));
        Assert.That(queue.Properties.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(queuePropertyDuplicateDetectionHistoryTimeWindow));
        Assert.That(queue.Properties.ForwardDeadLetteredMessagesTo, Is.EqualTo(queuePropertyForwardDeadLetteredMessagesTo));
        Assert.That(queue.Properties.ForwardTo, Is.EqualTo(queuePropertyForwardTo));
        Assert.That(queue.Properties.LockDuration, Is.EqualTo(queuePropertyLockDuration));
        Assert.That(queue.Properties.MaxDeliveryCount, Is.EqualTo(queuePropertyMaxDeliveryCount));
        Assert.That(queue.Properties.RequiresDuplicateDetection, Is.EqualTo(queuePropertyRequiresDuplicateDetection));
        Assert.That(queue.Properties.RequiresSession, Is.EqualTo(queuePropertyRequiresSession));
        
        //Topic
        var topic = configurationNamespace.Topics.Single(t => t.Name == topicName);
        Assert.That(topic.Name, Is.EqualTo(topicName));
        Assert.That(topic.Properties.RequiresDuplicateDetection, Is.EqualTo(topicPropertiesRequiresDuplicateDetection));
        Assert.That(topic.Properties.DefaultMessageTimeToLive, Is.EqualTo(topicPropertiesDefaultMessageTimeToLive));
        Assert.That(topic.Properties.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(topicPropertiesDuplicateDetectionHistoryTimeWindow));
        
        //Subscription
        var subscription = topic.Subscriptions.Single(s => s.Name == subscriptionName);
        Assert.That(subscription.Name, Is.EqualTo(subscriptionName));
        Assert.That(subscription.Properties.DeadLetteringOnMessageExpiration, Is.EqualTo(subscriptionPropertyDeadLetteringOnMessageExpiration));
        Assert.That(subscription.Properties.DefaultMessageTimeToLive, Is.EqualTo(subscriptionPropertyDefaultMessageTimeToLive));
        Assert.That(subscription.Properties.DuplicateDetectionHistoryTimeWindow, Is.EqualTo(subscriptionPropertyDuplicateDetectionHistoryTimeWindow));
        Assert.That(subscription.Properties.ForwardDeadLetteredMessagesTo, Is.EqualTo(subscriptionPropertyForwardDeadLetteredMessagesTo));
        Assert.That(subscription.Properties.ForwardTo, Is.EqualTo(subscriptionPropertyForwardTo));
        Assert.That(subscription.Properties.LockDuration, Is.EqualTo(subscriptionPropertyLockDuration));
        Assert.That(subscription.Properties.MaxDeliveryCount, Is.EqualTo(subscriptionPropertyMaxDeliveryCount));
        Assert.That(subscription.Properties.RequiresDuplicateDetection, Is.EqualTo(subscriptionPropertyRequiresDuplicateDetection));
        Assert.That(subscription.Properties.RequiresSession, Is.EqualTo(subscriptionPropertyRequiresSession));

        var rule = subscription.Rules.Single(r => r.Name == subscriptionRuleName);
        Assert.That(rule.Name, Is.EqualTo(subscriptionRuleName));
        Assert.That(rule.Properties.FilterType, Is.EqualTo(subscriptionRuleType));
        Assert.That(rule.Properties.CorrelationFilter.CorrelationId, Is.EqualTo(subscriptionRuleCorrelationId));
        Assert.That(rule.Properties.CorrelationFilter.ContentType, Is.EqualTo(subscriptionRuleContentType));
        Assert.That(rule.Properties.CorrelationFilter.CorrelationId, Is.EqualTo(subscriptionRuleCorrelationId));
        Assert.That(rule.Properties.CorrelationFilter.Label, Is.EqualTo(subscriptionRuleLabel));
        Assert.That(rule.Properties.CorrelationFilter.MessageId, Is.EqualTo(subscriptionRuleMessageId));
        Assert.That(rule.Properties.CorrelationFilter.ReplyTo, Is.EqualTo(subscriptionRuleReplyTo));
        Assert.That(rule.Properties.CorrelationFilter.ReplyToSessionId, Is.EqualTo(subscriptionRuleReplyToSessionId));
        Assert.That(rule.Properties.CorrelationFilter.SessionId, Is.EqualTo(subscriptionRuleSessionId));
        Assert.That(rule.Properties.CorrelationFilter.To, Is.EqualTo(subscriptionRuleTo));

        Assert.That(configuration.UserConfig.Logging.Type, Is.EqualTo(loggingType));
    }
}
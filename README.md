## AzureServiceBusEmulator.Configuration Package

This library contains a library that can be used to programaticaly generate Configuration files for [Azure Service Bus Emulator](https://learn.microsoft.com/en-us/azure/service-bus-messaging/overview-emulator) so that they can be used for local development setups.

This Package can be downloaded from nuget [link](https://www.nuget.org/packages/ReardonTech.AzureServiceBusEmulator.Configuration) and is found under the namespace `ReardonTech.AzureServiceBusEmulator.Configuration`

### The Configuration Builder
The configuration Builder `AsbEmulatorConfigurationBuilder` is the entry-point into this project

The Create configuration for a Namespace with two Queues and a Topic

```csharp
var asbEmulatorConfig = AsbEmulatorConfigurationBuilder.WithNamespace("local", nOptions => 
    nOptions.WithQueue("Queue1")
        .WithQueue("Queue2")
        .WithTopic("Topic1", tOptions =>
            tOptions.WithSubscription("Subscription1")
                .WithSubscription("Subscription2"))
    ).Build();

File.WriteAllText("Config.json", JsonSerializer.Serialize(asbEmulatorConfig, new JsonSerializerOptions() { WriteIndented = true }));
```

This will produce the following Config file:

```json
{
  "UserConfig" : {
    "Namespaces" : [ {
      "Name" : "local",
      "Queues" : [ {
        "Name" : "Queue1",
        "Properties" : {
          "DeadLetteringOnMessageExpiration" : false,
          "DefaultMessageTimeToLive" : "PT1H",
          "DuplicateDetectionHistoryTimeWindow" : "PT20S",
          "ForwardDeadLetteredMessagesTo" : "",
          "ForwardTo" : "",
          "LockDuration" : "PT1M",
          "MaxDeliveryCount" : 3,
          "RequiresDuplicateDetection" : false,
          "RequiresSession" : false
        }
      }, {
        "Name" : "Queue2",
        "Properties" : {
          "DeadLetteringOnMessageExpiration" : false,
          "DefaultMessageTimeToLive" : "PT1H",
          "DuplicateDetectionHistoryTimeWindow" : "PT20S",
          "ForwardDeadLetteredMessagesTo" : "",
          "ForwardTo" : "",
          "LockDuration" : "PT1M",
          "MaxDeliveryCount" : 3,
          "RequiresDuplicateDetection" : false,
          "RequiresSession" : false
        }
      } ],
      "Topics" : [ {
        "Name" : "Topic1",
        "Properties" : {
          "DefaultMessageTimeToLive" : "PT1H",
          "DuplicateDetectionHistoryTimeWindow" : "PT20S",
          "RequiresDuplicateDetection" : false
        },
        "Subscriptions" : [ {
          "Name" : "Subscription1",
          "Properties" : {
            "DeadLetteringOnMessageExpiration" : false,
            "DefaultMessageTimeToLive" : "PT1H",
            "DuplicateDetectionHistoryTimeWindow" : "PT20S",
            "ForwardDeadLetteredMessagesTo" : "",
            "ForwardTo" : "",
            "LockDuration" : "PT1M",
            "MaxDeliveryCount" : 3,
            "RequiresDuplicateDetection" : false,
            "RequiresSession" : false
          },
          "Rules" : [ ]
        }, {
          "Name" : "Subscription2",
          "Properties" : {
            "DeadLetteringOnMessageExpiration" : false,
            "DefaultMessageTimeToLive" : "PT1H",
            "DuplicateDetectionHistoryTimeWindow" : "PT20S",
            "ForwardDeadLetteredMessagesTo" : "",
            "ForwardTo" : "",
            "LockDuration" : "PT1M",
            "MaxDeliveryCount" : 3,
            "RequiresDuplicateDetection" : false,
            "RequiresSession" : false
          },
          "Rules" : [ ]
        } ]
      } ]
    } ],
    "Logging" : {
      "Type" : "File"
    }
  }
}
```

### Samples
  - [ASBExample](samples/ASBExample/Readme.md) : This is a Basic Example the that generates the ASB Emulator Config file based on all Topics that it knows about.
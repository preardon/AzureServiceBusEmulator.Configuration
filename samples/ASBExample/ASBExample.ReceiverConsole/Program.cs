using System.Text.Json;
using ASBExample.Shared;
using Azure.Messaging.ServiceBus;
using ReardonTech.AzureServiceBusEmulator.Configuration;

const string workerSubscription = "ASBExample-ReceiverConsole";

#if DEBUG
// Generate Files
var asbEmulatorConfig = AsbEmulatorConfigurationBuilder.WithNamespace("local", nOptions =>
{
    foreach (var topic in MessageAddresses.Topics)
    {
        nOptions.WithTopic(topic.Value, tOptions => tOptions.WithSubscription(workerSubscription));
    }
}).Build();

var contentPath = AppDomain.CurrentDomain.BaseDirectory;
File.WriteAllText(Path.Combine(contentPath, "..\\..\\..\\..\\Config.json"), JsonSerializer.Serialize(asbEmulatorConfig, new JsonSerializerOptions() { WriteIndented = true }));

#endif
// Rest of Application

var client = new ServiceBusClient("Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;");

var commandProcessor = client.CreateProcessor(MessageAddresses.GetTopic<GreetingCommand>(), workerSubscription);
commandProcessor.ProcessMessageAsync += async (ProcessMessageEventArgs args) =>
{
    var greeting = args.Message.Body.ToObjectFromJson<GreetingCommand>();
    var greetingName = greeting?.Name ?? "Name Unknown";
    var greetingMessage = "Hello " + greetingName;
    
    Console.WriteLine(greetingMessage);
    var sender = client.CreateSender(MessageAddresses.GetTopic<GreetingEvent>());
    
    var greetingEvent = new GreetingEvent(greetingName, greetingMessage);
    await sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(greetingEvent)));
};
commandProcessor.ProcessErrorAsync += (ProcessErrorEventArgs args) => { Console.WriteLine(args.Exception);
    return Task.CompletedTask;
};

var eventProcessor = client.CreateProcessor(MessageAddresses.GetTopic<GreetingEvent>(), workerSubscription);
eventProcessor.ProcessMessageAsync += (ProcessMessageEventArgs args) =>
{
    Console.WriteLine(args.Message.Body.ToObjectFromJson<GreetingEvent>());
    return Task.CompletedTask;
};
eventProcessor.ProcessErrorAsync += (ProcessErrorEventArgs args) => { Console.WriteLine(args.Exception);
    return Task.CompletedTask;
};

await commandProcessor.StartProcessingAsync(CancellationToken.None);
await eventProcessor.StartProcessingAsync(CancellationToken.None);

Console.WriteLine("Press any key to stop the receiver.");
Console.ReadKey();
await commandProcessor.StopProcessingAsync(CancellationToken.None);
await eventProcessor.StopProcessingAsync(CancellationToken.None);
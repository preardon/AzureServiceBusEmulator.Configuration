using System.Text.Json;
using ASBExample.Shared;
using Azure.Messaging.ServiceBus;

var client =
    new ServiceBusClient(
        "Endpoint=sb://localhost;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;");

var greetingSender = client.CreateSender(MessageAddresses.GetTopic<GreetingCommand>());

Console.WriteLine("Type any name and press Enter to send a greeting, or q and enter to exit:");

var running = true;
while (running)
{
    var input = Console.ReadLine() ?? "Name not Provided";
    if(input == "q")
        running = false;
    else
    {
        var greetingCommand = new GreetingCommand(input);
        await greetingSender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(greetingCommand)));
    }
}
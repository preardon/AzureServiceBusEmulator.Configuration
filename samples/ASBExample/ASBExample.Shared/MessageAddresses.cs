namespace ASBExample.Shared;

public static class MessageAddresses
{
    public static Dictionary<Type, string> Topics = new();

    static MessageAddresses()
    {
        Topics.Add(typeof(GreetingCommand), "ASBExample.GreetingCommand");
        Topics.Add(typeof(GreetingEvent), "ASBExample.GreetingEvent");
    }
    
    public static string GetTopic<T>() => Topics[typeof(T)];
}
namespace ASBExample.Shared;

/// <summary>
/// Person has been Greeted
/// </summary>
/// <param name="Name">The name of the Person that was Greeted</param>
/// <param name="Message">The message used to Greet the Person</param>
public record GreetingEvent(string Name, string Message);
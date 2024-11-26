namespace ASBExample.Shared;

/// <summary>
/// Send a Greeting
/// </summary>
/// <param name="Name">The name of the person to greet</param>
public record GreetingCommand(string Name);
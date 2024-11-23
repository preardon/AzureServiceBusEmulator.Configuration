using ReardonTech.AzureServiceBusEmulator.Configuration.Builders;
using ReardonTech.AzureServiceBusEmulator.Configuration.Model;

namespace ReardonTech.AzureServiceBusEmulator.Configuration;

public class AsbEmulatorConfigurationBuilder()
{
    private string _loggingType = "File";
    
    private List<AsbNamespace> _namespaces = new List<AsbNamespace>();
    
    /// <summary>
    /// Include configuration for A ASB Namepsace
    /// </summary>
    /// <param name="asbNamespace"></param>
    /// <returns></returns>
    private AsbEmulatorConfigurationBuilder WithNameSpace(AsbNamespaceBuilder asbNamespace)
    {
        _namespaces.Add(asbNamespace.Build());
        return this;
    }

    /// <summary>
    /// Add a Namespace to the configuration.
    /// </summary>
    /// <param name="name">The name of the namepsace</param>
    /// <param name="namespaceOptions"></param>
    /// <returns>ASB Emulator Configuration Builder</returns>
    public static AsbEmulatorConfigurationBuilder WithNamespace(string name, Action<AsbNamespaceBuilder> namespaceOptions)
    {
        var asbNamespaceBuilder = new AsbNamespaceBuilder(name);
        namespaceOptions.Invoke(asbNamespaceBuilder);
        return new AsbEmulatorConfigurationBuilder().WithNameSpace(asbNamespaceBuilder);
    }

    /// <summary>
    /// Configure the Logging for this ASB Emulator
    /// </summary>
    /// <param name="loggingType">What type of logging to use (default: 'File')</param>
    /// <returns>ASB Emulator Configuration Builder</returns>
    public AsbEmulatorConfigurationBuilder WithLogging(string loggingType)
    {
        _loggingType = loggingType;
        return this;
    }
    
    /// <summary>
    /// Build the Configuration
    /// </summary>
    /// <returns>Azure Service Bus Emulator Configuration</returns>
    public AsbConfig Build()
        => new AsbConfig(new UserConfig(_namespaces.ToArray(), new AsbLogging(_loggingType)));
}
namespace FunTimesItemCraftingNetwork;

class CraftingTerminal : IAttachable, IRequester
{
    private List<IProvider> _providers = new List<IProvider>();

    public bool CheckAvailability(Item item)
    {
        Console.WriteLine($"Checking if {item} is available in the network...");
        var available =  _providers.Any(p => p.Query(item));
        Console.WriteLine(available ? "Yep!" : "Nope.");
        return available;
    }
    
    public void Attach(Connector connector)
    {
        Subscribe(connector);
    }

    public void Detach(Connector connector)
    {
        Unsubscribe(connector);
    }

    public void Subscribe(IProvider provider)
    {
        if (_providers.Contains(provider)) return;
        _providers.Add(provider);
    }

    public void Unsubscribe(IProvider provider)
    {
        _providers.Remove(provider);
    }
}
namespace FunTimesItemCraftingNetwork;

class Connector: IProvider, IRequester
{
    private List<IProvider> _providers = new List<IProvider>();

    public bool Query(Item item)
    {
        return _providers.Any(p => p.Query(item));
    }

    public Item Request(Item item)
    {
        throw new NotImplementedException();
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
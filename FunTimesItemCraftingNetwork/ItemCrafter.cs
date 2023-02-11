namespace FunTimesItemCraftingNetwork;

class ItemCrafter : IProvider, IRequester, IAttachable
{
    private readonly Item[] _requiredItems;
    private readonly Item _providedItem;
    private readonly List<IProvider> _providers = new List<IProvider>();

    public ItemCrafter(Item[] requiredItems, Item providedItem)
    {
        _requiredItems = requiredItems;
        _providedItem = providedItem;
    }
    public bool Query(Item item)
    {
        return item == _providedItem && _requiredItems.All(i => _providers.Any(p => p.Query(i)));
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

    public void Attach(Connector connector)
    {
        connector.Subscribe(this);
        Subscribe(connector);
    }

    public void Detach(Connector connector)
    {
        connector.Unsubscribe(this);
        Unsubscribe(connector);
    }
}
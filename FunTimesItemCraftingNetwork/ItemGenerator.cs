namespace FunTimesItemCraftingNetwork;

class ItemGenerator : IProvider, IAttachable
{
    private readonly Item _providedItem;

    public ItemGenerator(Item providedItem)
    {
        _providedItem = providedItem;
    }
    public bool Query(Item item)
    {
        return item == _providedItem;
    }

    public Item Request(Item item)
    {
        return _providedItem;
    }

    public void Attach(Connector connector)
    {
        connector.Subscribe(this);
    }

    public void Detach(Connector connector)
    {
        connector.Unsubscribe(this);
    }
}
namespace FunTimesItemCraftingNetwork;

interface IRequester
{
    void Subscribe(IProvider provider);
    void Unsubscribe(IProvider provider);
}
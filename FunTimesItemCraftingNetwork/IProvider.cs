namespace FunTimesItemCraftingNetwork;

interface IProvider
{
    bool Query(Item item);
    Item Request(Item item);
}
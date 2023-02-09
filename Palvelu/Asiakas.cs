namespace Palvelu;

class Asiakas
{
    private IProduct? _product;

    public void Use(IProduct product)
    {
        _product = product;
    }

    public string Operaatio()
    {
        return _product?.Service() ?? "No result.";
    }
}
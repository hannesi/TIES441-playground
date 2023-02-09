using Tehdastelu;

class Platform : IFactoryRegistry
{
    private IFactory? _factory;
    public void Register(IFactory factory)
    {
        _factory = factory;
    }

    public string Testiajo()
    {
        if (_factory != null)
        {
            var apulainen = _factory.Create();
            var komponentti = new Asiakas();
            komponentti.Use(apulainen);
            return komponentti.Operaatio();
        }
        else
        {
            return "Ei tehdasta, ei toimintaa...";
        }
    }
}
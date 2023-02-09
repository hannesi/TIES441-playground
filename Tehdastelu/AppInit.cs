namespace Tehdastelu;

class AppInit
{
    private class AppProduct : IProduct
    {
        public string Service()
        {
            Console.WriteLine("hurinaa ja vilkkuvia valoja");
            return "koira haukkuu";
        }
    }

    private class AppFactory : IFactory
    {
        public IProduct Create()
        {
            return new AppProduct();
        }
    }


    public AppInit(IFactoryRegistry app)
    {
        app.Register(new AppFactory());
    }
}
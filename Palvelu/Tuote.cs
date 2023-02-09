using Palvelu;

class Tuote : IProduct
{
    public string Service()
    {
        Console.WriteLine("palvelu laskee ja aprikoi");
        return "kissa istuu";
    }
}
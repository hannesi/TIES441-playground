using Palvelu;

class ToinenTuote : IProduct
{
    public string Service()
    {
        Console.WriteLine("raksutusta ja pöhinää");
        return "lehmä pyöräilee";
    }
}
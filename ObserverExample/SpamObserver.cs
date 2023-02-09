namespace ObserverExample;

internal class SpamObserver: IObserver<Event>
{
    private readonly string _name;

    public SpamObserver(string name)
    {
        _name = name;
    }

    public void Update(Event e)
    {
        Console.WriteLine($"{_name}: {e.Message}");
    }
}
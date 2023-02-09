namespace ObserverExample;

internal class StringSpammer: ISource<Event>
{
    private readonly List<IObserver<Event>> _observers;

    public StringSpammer()
    {
        _observers = new List<IObserver<Event>>();
    }

    public void Spam(Event e)
    {
        _observers.ForEach(o => o.Update(e));
    }
    public void Register(IObserver<Event> observer)
    {
        if (_observers.Contains(observer)) return;
        _observers.Add(observer);
    }

    public void Unregister(IObserver<Event> observer)
    {
        _observers.Remove(observer);
    }
}
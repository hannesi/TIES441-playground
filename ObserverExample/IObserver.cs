namespace ObserverExample;

internal interface IObserver<T>
{
    void Update(Event e);
}
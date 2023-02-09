namespace ObserverExample;

internal interface ISource<T>
{
    void Register(IObserver<T> observer);
    void Unregister(IObserver<T> observer);
}
using ObserverExample;

var source = new StringSpammer();
var observers = new List<SpamObserver>()
{
    new("Aatami"),
    new("Bertta"),
    new("Cecile"),
    new("Daavid"),
};
observers.ForEach(o => source.Register(o));
source.Spam(new Event("hello world"));
source.Unregister(observers[2]);
source.Spam(new Event("Hello, World!"));

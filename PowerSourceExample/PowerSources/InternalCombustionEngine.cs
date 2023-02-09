using PowerSourceExample.PowerSourceUsers;

namespace PowerSourceExample.PowerSources;

public class InternalCombustionEngine: IPowerSource
{
    private IPowerSourceUser? _user;
    public void Start()
    {
        Console.WriteLine("ICE: I'm now running :-)");
    }

    public void Stop()
    {
        Console.WriteLine("ICE: I'm no longer running :-(");
    }

    public void SetUser(IPowerSourceUser user)
    {
        _user = user;
    }

    public void SendManualWarning(string warning)
    {
        _user?.Warn(warning);
    }
}
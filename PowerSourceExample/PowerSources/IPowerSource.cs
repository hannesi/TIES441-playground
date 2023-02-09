using PowerSourceExample.PowerSourceUsers;

namespace PowerSourceExample.PowerSources;

public interface IPowerSource
{
    void Start();
    void Stop();
    void SetUser(IPowerSourceUser user);
}
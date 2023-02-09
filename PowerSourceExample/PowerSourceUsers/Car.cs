using PowerSourceExample.PowerSources;

namespace PowerSourceExample.PowerSourceUsers;

public class Car: IPowerSourceUser
{
    private IPowerSource? _powerSource;
    public Car(IPowerSource? powerSource = null)
    {
        if (powerSource != null) SetPowerSource(powerSource);
    }

    public void SetPowerSource(IPowerSource powerSource)
    {
        _powerSource = powerSource;
        _powerSource.SetUser(this);
    }

    public void Warn(string warning)
    {
        Console.WriteLine($"Received warning from my power source: {warning}\nCommanding the power source to stop...");
        _powerSource?.Stop();
    }

    public void Start()
    {
        if (_powerSource != null)
        {
            Console.WriteLine("Car: I'm about to command my power source to start.");
            _powerSource.Start();
        }
        else
        {
            Console.WriteLine("Car: No engine, no putput. :-(");
        }
    }
}
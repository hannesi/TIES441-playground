using PowerSourceExample.PowerSources;
using PowerSourceExample.PowerSourceUsers;

var eng = new InternalCombustionEngine();
var car = new Car();
car.Start();
car.SetPowerSource(eng);
car.Start();
eng.SendManualWarning("I'm tired.");
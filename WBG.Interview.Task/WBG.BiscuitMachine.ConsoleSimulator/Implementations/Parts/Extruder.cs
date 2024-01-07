using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Extruder : IExtruder
{
    private readonly ICookieFactory _cookieFactory;

    public Extruder(ICookieFactory cookieFactory)
    {
        _cookieFactory = cookieFactory;
    }

    public Cookie ExtrudeCookie(IConveyor conveyor)
    {
        Console.WriteLine("Extruder Pulses");
        var newCookie = _cookieFactory.CreateCookie(); // Create a new cookie from the factory
        conveyor.EnqueueCookie(newCookie); // Enqueue the raw cookie to the conveyor
        Console.WriteLine("Extruding cookie...");
        Thread.Sleep(1000); // Simulate 1 second delay
        return newCookie; // Return the extruded raw cookie
    }
}

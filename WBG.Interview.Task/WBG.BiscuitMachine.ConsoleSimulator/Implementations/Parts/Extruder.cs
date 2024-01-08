using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Extruder : IExtruder
{
    private readonly ICookieFactory _cookieFactory;
    private readonly IConveyor _conveyor;

    public Extruder(
        ICookieFactory cookieFactory,
        IConveyor conveyor)
    {
        _cookieFactory = cookieFactory;
        _conveyor = conveyor;
    }

    public Cookie ExtrudeCookie()
    {
        Console.WriteLine("Extruder Pulses");
        var newCookie = _cookieFactory.CreateCookie(); // Create a new cookie from the factory
        _conveyor.EnqueueCookie(newCookie); // Enqueue the raw cookie to the conveyor

        Thread.Sleep(1000); // Simulate 1 second delay
        Console.WriteLine("Extruding cookie...");
        return newCookie; // Return the extruded raw cookie
    }
}

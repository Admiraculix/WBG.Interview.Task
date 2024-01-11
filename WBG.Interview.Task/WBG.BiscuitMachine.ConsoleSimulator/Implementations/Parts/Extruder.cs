using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Extruder : IExtruder
{
    private readonly ICookieFactory _cookieFactory;
    private readonly IConveyor _conveyor;

    private CancellationTokenSource _tokenSource;

    public Extruder(
        ICookieFactory cookieFactory,
        IConveyor conveyor)
    {
        _cookieFactory = cookieFactory;
        _conveyor = conveyor;
        _tokenSource = new CancellationTokenSource();
}

    public int CurrentPulse { get; set; }

    public void Stop()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Extruding canceled!");
        Console.ResetColor();

        _tokenSource.Cancel();
    }

    public Cookie ExtrudeCookie()
    {
        var newCookie = _cookieFactory.CreateCookie(); // Create a new cookie from the factory
        _conveyor.EnqueueCookie(newCookie); // Enqueue the raw cookie to the conveyor

        try
        {
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{CurrentPulse} Extruder Pulses -> Extruding new raw cookie...");
            Console.ResetColor();

            _tokenSource.Token.ThrowIfCancellationRequested();
        }
        catch (Exception)
        {
            _tokenSource = new CancellationTokenSource();
            Console.WriteLine("Extruding canceled!");
        }

        return newCookie;
    }
}

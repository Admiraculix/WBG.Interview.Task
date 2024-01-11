using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Stamper : IStamper
{
    private readonly IConveyor _conveyor;

    private CancellationTokenSource _tokenSource;
    public Stamper(IConveyor conveyor)
    {
        _conveyor = conveyor;
        _tokenSource = new CancellationTokenSource();
    }

    public int CurrentPulse { get; set; }

    public void Stop()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Stamping canceled!");
        Console.ResetColor();

        _tokenSource.Cancel();
    }

    public void StampCookie(Cookie cookie)
    {
        cookie.Thickness -= GenerateRandomStamperThickness(); // Reduce thickness by ~15mm
        cookie.State = new PreparedCookieState(); // Change state to prepared

        try
        {
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{CurrentPulse} Stamper Pulses -> Stamping new prepared cookie!");
            Console.ResetColor();

            _tokenSource.Token.ThrowIfCancellationRequested();
        }
        catch (Exception)
        {
            _tokenSource = new CancellationTokenSource();
            Console.WriteLine("Stamping canceled!");
        }
    }

    private static int GenerateRandomStamperThickness()
    {
        Random random = new Random();

        // Assuming stamper thickness is measured in millimeters
        int minThickness = 20;
        int maxThickness = 30;

        return random.Next(minThickness, maxThickness + 1);
    }
}

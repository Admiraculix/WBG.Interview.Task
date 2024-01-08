using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Stamper : IStamper
{
    public void Pulse()
    {
        Console.WriteLine("Stamper Pulses");
    }

    public void StampCookie(Cookie cookie)
    {
        Console.WriteLine("Stamping cookie...");
        cookie.Thickness -= GenerateRandomStamperThickness(); // Reduce thickness by 10mm
        cookie.State = new PreparedCookieState(); // Change state to prepared

        Thread.Sleep(1000); // Delay for 1 second
        Console.WriteLine("Cookie stamped!");
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

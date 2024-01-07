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
        cookie.Thickness -= 10; // Reduce thickness by 10mm
        cookie.State = new PreparedCookieState(); // Change state to prepared
        Console.WriteLine("Cookie stamped!");
    }
}

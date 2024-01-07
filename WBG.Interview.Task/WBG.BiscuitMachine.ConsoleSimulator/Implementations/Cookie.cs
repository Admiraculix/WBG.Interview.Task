using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

namespace WBG.BiscuitMachine.ConsoleSimulator;

public class Cookie
{
    public Cookie()
    {
        State = new RawCookieState();
        Weight = 12.2;
        Thickness = 40.0;
    }

    public double Weight { get; set; }
    public double Thickness { get; set; }
    public ICookieState State { get; set; }

    public override string ToString()
    {
        return $"Weight: {Weight}g, Thickness: {Thickness}mm, State: {State.GetType().Name}";
    }
}

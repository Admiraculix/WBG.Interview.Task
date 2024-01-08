using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

public class CookedCookieState : ICookieState
{
    public void Process(Cookie cookie)
    {
        Console.WriteLine(this.ToString());
    }

    public override string ToString()
    {
        return "Cookie is Cooked!";
    }
}

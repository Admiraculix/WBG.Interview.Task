using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;

namespace WBG.BiscuitMachine.ConsoleSimulator;

public class CookieFactory : ICookieFactory
{
    public Cookie CreateCookie()
    {
        return new Cookie();
    }
}

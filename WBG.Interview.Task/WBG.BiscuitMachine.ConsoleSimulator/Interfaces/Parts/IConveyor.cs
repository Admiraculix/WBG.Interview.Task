using WBG.BiscuitMachine.ConsoleSimulator.Implementations;

namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IConveyor
{
    void DequeueCookie();
    void EnqueueCookie(Cookie cookie);
    void Start();
}
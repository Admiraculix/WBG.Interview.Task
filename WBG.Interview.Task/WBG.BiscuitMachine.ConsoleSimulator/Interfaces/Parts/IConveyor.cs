namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IConveyor
{
    void DequeueCookie();
    void EnqueueCookie(Cookie cookie);
    void Start();
    void Stop();
    void Continue();
}
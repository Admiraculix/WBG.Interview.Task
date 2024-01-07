namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IStamper
{
    void Pulse();
    void StampCookie(Cookie newCookie);
}
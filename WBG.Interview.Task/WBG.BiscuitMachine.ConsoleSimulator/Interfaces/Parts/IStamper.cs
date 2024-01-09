namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IStamper
{
    void StampCookie(Cookie cookie);
    int CurrentPulse { get; set; }
}
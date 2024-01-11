namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IExtruder
{
    void Stop();
    Cookie ExtrudeCookie();
    int CurrentPulse { get; set; }
}
namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IExtruder
{
    Cookie ExtrudeCookie();
   int CurrentPulse { get; set; }
}
using WBG.BiscuitMachine.ConsoleSimulator.Implementations;

namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IExtruder
{
    Cookie ExtrudeCookie(IConveyor conveyor);
}
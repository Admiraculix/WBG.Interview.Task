using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

public class MachinePausedState : IState
{
    private readonly ISwitch _switch;

    public MachinePausedState(ISwitch machineSwitch)
    {
        _switch = machineSwitch;
    }

    public void Handle()
    {
        Console.WriteLine("Machine is Paused");
        _switch.TurnOff(); // Turn off the machine when paused
    }
}

using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

// States for the machine
public class MachineOffState : IState
{
    public void Handle()
    {
        Console.WriteLine("Machine is Off");
    }
}

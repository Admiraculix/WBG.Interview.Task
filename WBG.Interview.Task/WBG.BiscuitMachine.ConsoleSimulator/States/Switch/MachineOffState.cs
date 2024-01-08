using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

public class MachineOffState : IState
{
    public void Handle()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Emotes.Stop} Machine is Off");
        Console.ResetColor();
    }
}


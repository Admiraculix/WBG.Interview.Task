using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

public class MachinePausedState : IState
{
    public void Handle()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Emotes.Pause} Machine is Paused");
        Console.ResetColor();
    }
}

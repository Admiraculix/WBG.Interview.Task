using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Motor : IMotor
{
    public void Start()
    {
        Console.WriteLine($"{Emotes.Gear} Motor Started - One pulse per revolution");
    }

    public void Stop()
    {
        Console.WriteLine($"{Emotes.Gear} Motor Stopped");
    }
}

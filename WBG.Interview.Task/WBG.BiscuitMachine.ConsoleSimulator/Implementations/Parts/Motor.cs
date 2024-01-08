using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Motor : IMotor
{
    private readonly IConveyor _conveyor;

    public Motor(IConveyor conveyor)
    {
        _conveyor = conveyor;
    }

    public void Start()
    {
        Console.WriteLine($"{Emotes.Gear} Motor Started - One pulse per revolution");
        _conveyor.Start();
    }

    public void Stop()
    {
        Console.WriteLine($"{Emotes.Gear} Motor Stopped");
    }
}

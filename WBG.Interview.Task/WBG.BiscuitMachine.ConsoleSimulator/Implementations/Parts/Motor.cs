using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Motor : IMotor
{
    private readonly IConveyor _conveyor;

    public Motor(IConveyor conveyor)
    {
        _conveyor = conveyor;
    }

    public void Start(IState currentState)
    {
        if (currentState is MachineOnState)
        {
            Console.WriteLine($"{Emotes.Gear} Motor Started - One pulse per revolution");
            _conveyor.Start();
        }
    }

    public void Stop(IState currentState)
    {
        if (currentState is MachineOffState)
        {
            Console.WriteLine($"{Emotes.Gear} Motor Stopped");
            _conveyor.Continue();
        }
    }

    public void Pause(IState currentState)
    {
        if (currentState is MachinePausedState)
        {
            Console.WriteLine($"{Emotes.Gear} Motor Paused");
            _conveyor.Stop();
        }
    }
}

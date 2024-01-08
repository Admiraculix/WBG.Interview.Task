using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Motor : IMotor
{
    private readonly IConveyor _conveyor;
    private readonly ISwitch _switch;


    public Motor(IConveyor conveyor, ISwitch @switch)
    {
        _conveyor = conveyor;
        _switch = @switch;
    }

    public void Start()
    {
        if (_switch is MachineOnState)
        {
            Console.WriteLine($"{Emotes.Gear} Motor Started - One pulse per revolution");
            _conveyor.Start();
        }
    }

    public void Stop()
    {
        if (_switch is MachineOffState)
        {
            Console.WriteLine($"{Emotes.Gear} Motor Stopped");
        }
    }

    public void Pause()
    {
        if (_switch is MachinePausedState)
        {
            Console.WriteLine($"{Emotes.Gear} Motor Paused");
        }
    }
}

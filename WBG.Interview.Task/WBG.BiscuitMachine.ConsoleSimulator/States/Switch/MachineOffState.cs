using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

public class MachineOffState : IState
{
    private readonly IMotor _motor;

    public MachineOffState(IMotor motor)
    {
        _motor = motor;
    }

    public void Handle()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Emotes.Stop} Machine is Off");
        Console.ResetColor();

        _motor.Stop(this);
    }
}


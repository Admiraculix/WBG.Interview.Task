using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

public class MachineOnState : IState
{
    private readonly IOven _oven;
    private readonly IMotor _motor;

    public MachineOnState(IOven oven, IMotor motor)
    {
        _oven = oven;
        _motor = motor;
    }

    public void Handle()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Emotes.Play} Machine is On");
        Console.ResetColor();

        _oven.TurnOnHeatingElement();

        if (_oven.IsHeatingElementOn)
        {
            _motor.Start(this);
        }
    }
}



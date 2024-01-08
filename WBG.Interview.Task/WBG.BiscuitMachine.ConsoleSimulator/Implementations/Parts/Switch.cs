using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Switch : ISwitch
{
    private readonly IOven _oven;
    private readonly IMotor _motor;

    private IState _currentState;

    public Switch(IOven oven, IMotor motor)
    {
        _oven = oven;
        _motor = motor;
        _currentState = new MachineOffState(_motor);
    }

    public void TurnOn()
    {
        _currentState = new MachineOnState(_oven, _motor);
        _currentState.Handle();
    }

    public void TurnOff()
    {
        _currentState = new MachineOffState(_motor);
        _currentState.Handle();
    }

    public void Pause()
    {
        _currentState = new MachinePausedState();
        _currentState.Handle();
    }

    public IState GetState => _currentState;
}

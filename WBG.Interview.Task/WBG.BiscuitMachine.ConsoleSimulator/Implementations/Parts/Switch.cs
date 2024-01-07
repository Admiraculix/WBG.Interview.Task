using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Switch : ISwitch
{
    private IState _currentState;
    private IOven _oven;
    public Switch(IOven oven)
    {
        // Initial state is Off
        _currentState = new MachineOffState();
        _oven = oven;
    }

    public void TurnOn()
    {
        _currentState = new MachineOnState(_oven);
        _currentState.Handle();
    }

    public void TurnOff()
    {
        _currentState = new MachineOffState();
        _currentState.Handle();
    }

    public void Pause()
    {
        _currentState = new MachinePausedState(this);
        _currentState.Handle();
    }

    public IState GetState => _currentState;
}

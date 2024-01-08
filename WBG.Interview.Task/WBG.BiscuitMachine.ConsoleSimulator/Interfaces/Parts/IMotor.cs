namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IMotor
{
    void Start(IState currentState);
    void Stop(IState currentState);
    void Pause(IState currentState);
}
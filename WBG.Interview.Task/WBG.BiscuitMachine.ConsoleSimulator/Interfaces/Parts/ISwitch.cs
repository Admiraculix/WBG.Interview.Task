namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface ISwitch
{
    void Pause();
    void TurnOff();
    void TurnOn();
    IState GetState { get; }
}
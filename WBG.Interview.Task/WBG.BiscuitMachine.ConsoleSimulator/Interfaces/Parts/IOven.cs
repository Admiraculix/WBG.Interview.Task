using WBG.BiscuitMachine.ConsoleSimulator.Implementations;

namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IOven
{
    void TurnOnHeatingElement();
    void TurnOffHeatingElement();
    void SetTemperature(int temperature);
    int GetTemperature();
    void BakeCookie(Cookie cookie, IConveyor conveyor);
}
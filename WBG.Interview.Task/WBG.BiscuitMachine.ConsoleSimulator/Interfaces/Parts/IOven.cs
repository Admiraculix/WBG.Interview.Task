namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IOven
{
    void TurnOnHeatingElement();
    void TurnOffHeatingElement();
    void SetTemperature(int temperature);
    int GetTemperature();
    void BakeCookie();
    void DisplayTemperature(string infoText = "Oven Temperature: ");
    bool IsHeatingElementOn { get; set; }
}
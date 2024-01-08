using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

public class MachineOnState : IState
{
    private readonly IOven _oven;

    public MachineOnState(IOven oven)
    {
        _oven = oven;
    }

    public void Handle()
    {
        Console.WriteLine($"{Emotes.Play} Machine is On");
        _oven.TurnOnHeatingElement();

        // Wait for the oven to warm up
        while (_oven.GetTemperature() < 245)
        {
            UpdatingTemperatureInSameLine();
            _oven.SetTemperature(_oven.GetTemperature() + 5);
        }

        _oven.SetTemperature(220);
        Console.WriteLine("\nOven is ready. Starting the conveyor belt.");
    }

    // Simulate a change in temperature
    public void UpdatingTemperatureInSameLine()
    {
        // Simulate a delay before updating the temperature
        Thread.Sleep(100);

        // Clear the current line
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));

        // Move the cursor back to the beginning of the line
        Console.SetCursorPosition(0, Console.CursorTop);

        // Update and print the new temperature
        Console.Write($"{Emotes.Thermometer} Oven Temperature: {_oven.GetTemperature()}°C");
    }
}



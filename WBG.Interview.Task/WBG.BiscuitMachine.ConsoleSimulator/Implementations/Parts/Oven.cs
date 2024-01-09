using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Oven : IOven
{
    private readonly IConveyor _conveyor;

    private bool _isHeatingElementOn;
    private int _temperature;

    public bool IsHeatingElementOn { get => _isHeatingElementOn; private set => _isHeatingElementOn = value; }

    public Oven(IConveyor conveyor)
    {
        _conveyor = conveyor;
    }

    public void TurnOnHeatingElement()
    {
        IsHeatingElementOn = true;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Oven Heating Element is On");

        // Wait for the oven to warm up
        while (GetTemperature() < 245)
        {
            UpdatingTemperatureInSameLine();
            SetTemperature(GetTemperature() + 5);
        }

        Console.WriteLine("\nOven is ready. Starting the conveyor belt.");
        Console.ResetColor();
    }

    public void TurnOffHeatingElement()
    {
        IsHeatingElementOn = false;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Oven Heating Element is Off");
        Console.ResetColor();
    }

    public void SetTemperature(int temperature)
    {
        _temperature = temperature;
    }

    public int GetTemperature()
    {
        return _temperature;
    }

    public void BakeCookie()
    {
        if (IsHeatingElementOn)
        {
            if (_conveyor.ConveyorBelt.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Baking cookie... Oven Temperature: ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{_temperature}°C\n");
                Console.ResetColor();

                // Simulate baking process (you can add more logic here)
                var currentCookie = _conveyor.DequeueCookie();
                currentCookie.State = new CookedCookieState(); // Change the state to cooked

                Thread.Sleep(5000); // Simulating 5 seconds of baking time

                Console.WriteLine($"{Emotes.Cookie} Cookie baked!\n\t{currentCookie}");
            }
        }
        else
        {
            if (_conveyor.ConveyorBelt.Count == 0)
            {
                Console.WriteLine("Cannot bake cookie. Heating element is off.");
            }
        }
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
        Console.Write($"{Emotes.Thermometer} Oven Temperature: {GetTemperature()}°C");
    }
}

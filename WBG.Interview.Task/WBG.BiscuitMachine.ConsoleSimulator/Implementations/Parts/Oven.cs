using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Oven : IOven
{
    private readonly IConveyor _conveyor;

    private bool _heatingElementOn;
    private int _temperature;

    public Oven(IConveyor conveyor)
    {
        _conveyor = conveyor;
    }

    public void TurnOnHeatingElement()
    {
        _heatingElementOn = true;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Oven Heating Element is On");
        Console.ResetColor();
    }

    public void TurnOffHeatingElement()
    {
        _heatingElementOn = false;
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

    public void BakeCookie(Cookie cookie)
    {
        if (_heatingElementOn)
        {
            Console.WriteLine($"Baking cookie... Oven Temperature: {_temperature}°C");
            // Simulate baking process (you can add more logic here)
            Thread.Sleep(5000); // Simulating 5 seconds of baking time
            cookie.State = new CookedCookieState(); // Change the state to cooked

            _conveyor.DequeueCookie();
            Console.WriteLine($"{Emotes.Cookie} Cookie baked!\n\t{cookie}");
        }
        else
        {
            Console.WriteLine("Cannot bake cookie. Heating element is off.");
        }
    }
}

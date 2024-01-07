using EmojiToolkit;
using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Oven : IOven
{
    private bool _heatingElementOn;
    private int _temperature;

    public void TurnOnHeatingElement()
    {
        _heatingElementOn = true;
        Console.WriteLine("Oven Heating Element is On");
    }

    public void TurnOffHeatingElement()
    {
        _heatingElementOn = false;
        Console.WriteLine("Oven Heating Element is Off");
    }

    public void SetTemperature(int temperature)
    {
        _temperature = temperature;
    }

    public int GetTemperature()
    {
        return _temperature;
    }

    public void BakeCookie(Cookie cookie, IConveyor conveyor)
    {
        if (_heatingElementOn)
        {
            Console.WriteLine($"Baking cookie... Oven Temperature: {_temperature}°C");
            // Simulate baking process (you can add more logic here)
            Thread.Sleep(1000); // Simulating 5 seconds of baking time
            cookie.State = new CookedCookieState(); // Change the state to cooked
            conveyor.DequeueCookie();
            Console.WriteLine($"{Emotes.Cookie} Cookie baked!\n\t{cookie}");
        }
        else
        {
            Console.WriteLine("Cannot bake cookie. Heating element is off.");
        }
    }
}

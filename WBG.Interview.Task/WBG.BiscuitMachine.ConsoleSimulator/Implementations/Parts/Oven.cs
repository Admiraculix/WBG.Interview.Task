﻿using System.Threading;
using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Cookies;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Oven : IOven
{
    private readonly IConveyor _conveyor;

    private bool _isHeatingElementOn;
    private int _temperature = 0;
    private CancellationTokenSource _tokenSource;

    public Oven(IConveyor conveyor)
    {
        _conveyor = conveyor;
        _tokenSource = new CancellationTokenSource();
    }
    public bool IsHeatingElementOn { get => _isHeatingElementOn; set => _isHeatingElementOn = value; }

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

        _tokenSource.Cancel();
    }

    public void SetTemperature(int temperature)
    {
        _temperature = temperature;

        if (temperature == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{Emotes.Thermometer} Oven Temperature: {GetTemperature()}°C");
            Console.ResetColor();
        }
    }

    public int GetTemperature()
    {
        return _temperature;
    }

    public void DisplayTemperature(string infoText = "Oven Temperature: ")
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{infoText}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{_temperature}°C\n");
        Console.ResetColor();
    }

    public void BakeCookie()
    {
        if (IsHeatingElementOn)
        {
            if (_conveyor.ConveyorBelt.Count > 0)
            {
                DisplayTemperature("Baking cookie... Oven Temperature: ");

                // Simulate baking process
                var currentCookie = _conveyor.DequeueCookie();
                currentCookie.State = new CookedCookieState(); // Change the state to cooked

                try
                {
                    // Simulating 5 seconds of baking time, with cancellation support
                    Thread.Sleep(5000);
                    _tokenSource.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{Emotes.Cookie} Cookie baked!\n\t{currentCookie}");
                }
                catch (Exception)
                {
                    _tokenSource = new CancellationTokenSource();
                    Console.WriteLine("Baking canceled.");
                }
            }
        }
        else
        {
            if (_conveyor.ConveyorBelt.Count == 0 && !IsHeatingElementOn)
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

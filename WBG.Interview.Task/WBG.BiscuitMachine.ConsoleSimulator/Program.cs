﻿using System.Runtime.InteropServices;
using System.Text;
using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Implementations;
using WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Switch;
using WBG.BiscuitMachine.ConsoleSimulator.Utilities;

namespace WBG.BiscuitMachine.ConsoleSimulator;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var osInfo = OSInformation.Info;
            Emotes.OSInfo = osInfo;
            //Console.WriteLine(osInfo);
        }

        // Create machine parts
        ICookieFactory cookieFactory = new CookieFactory();
        IBasket basket = new Basket();
        IConveyor conveyor = new Conveyor(basket);
        IExtruder extruder = new Extruder(cookieFactory, conveyor);
        IStamper stamper = new Stamper(conveyor);
        IOven oven = new Oven(conveyor);
        IMotor motor = new Motor(conveyor);
        ISwitch machineSwitch = new Switch(oven, motor);

        // Create the biscuit machine using DI
        BiscuitMachineSimulator biscuitMachine = new BiscuitMachineSimulator(machineSwitch, motor, extruder, stamper, oven, conveyor, basket);

        StartingLogo.DisplayLogo();
        biscuitMachine.Basket.DisplayCookieCount();
        Console.ResetColor();

        try
        {
            MainLoop(biscuitMachine);
        }
        catch (Exception ex)
        {
            MainLoop(biscuitMachine);
        }

    }

    public static void MainLoop(BiscuitMachineSimulator biscuitMachine)
    {
        // Simulation loop
        while (true)
        {
            // Check if a key is available
            if (Console.KeyAvailable)
            {
                SwitchBox.Control(biscuitMachine);
            }

            if (biscuitMachine.Switch.GetState is MachineOnState)
            {
                for (int i = 0; i < biscuitMachine.Motor.Revolutions; i++)
                {
                    biscuitMachine.Extruder.CurrentPulse = i + 1;
                    biscuitMachine.Stamper.CurrentPulse = i + 1;

                    var newCookie = biscuitMachine.Extruder.ExtrudeCookie();
                    biscuitMachine.Stamper.StampCookie(newCookie);
                }

                biscuitMachine.Oven.BakeCookie();

                biscuitMachine.Basket.DisplayCookieCount();
                Console.WriteLine($"---> {nameof(biscuitMachine.Conveyor.ConveyorBelt)} with cookie count to be baked: {biscuitMachine.Conveyor.ConveyorBelt.Count}!\n");
            }
            else if (biscuitMachine.Switch.GetState is MachineOffState)
            {
                if (biscuitMachine.Conveyor.ConveyorBelt.Count > 0 && biscuitMachine.Oven.GetTemperature() > 0)
                {
                    biscuitMachine.Oven.IsHeatingElementOn = true;
                    biscuitMachine.Oven.BakeCookie();
                    Console.WriteLine($"---> {nameof(biscuitMachine.Conveyor.ConveyorBelt)} with cookie count to be baked: {biscuitMachine.Conveyor.ConveyorBelt.Count}!\n");
                }
                else if (biscuitMachine.Conveyor.ConveyorBelt.Count == 0 && biscuitMachine.Oven.GetTemperature() > 0 && biscuitMachine.Switch.GetState is MachineOffState)
                {
                    biscuitMachine.Oven.IsHeatingElementOn = false;
                    biscuitMachine.Oven.SetTemperature(0);

                    SwitchBox.DisplayControlMenuOperations();
                    SwitchBox.Control(biscuitMachine);
                    // break;
                }
                else
                {
                    SwitchBox.DisplayControlMenuOperations();
                    SwitchBox.Control(biscuitMachine);
                }

                biscuitMachine.Basket.DisplayCookieCount();
            }
            else
            {
                SwitchBox.DisplayControlMenuOperations();
                biscuitMachine.Oven.DisplayTemperature();
                SwitchBox.Control(biscuitMachine);
            }
        }
    }
}
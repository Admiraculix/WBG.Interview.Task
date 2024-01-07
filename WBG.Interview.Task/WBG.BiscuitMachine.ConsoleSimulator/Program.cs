using EmojiToolkit;
using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Implementations;
using WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;
using WBG.BiscuitMachine.ConsoleSimulator.States.Switch;

namespace WBG.BiscuitMachine.ConsoleSimulator;

class Program
{
    static void Main()
    {
        // Create machine parts
        IOven oven = new Oven();
        ISwitch machineSwitch = new Switch(oven);
        IMotor motor = new Motor();
        ICookieFactory cookieFactory = new CookieFactory();
        IExtruder extruder = new Extruder(cookieFactory);
        IStamper stamper = new Stamper();
        IBasket basket = new Basket();
        IConveyor conveyor = new Conveyor(motor, basket);

        // Create the biscuit machine using DI
        BiscuitMachineSimulator biscuitMachine = new BiscuitMachineSimulator(machineSwitch, motor, extruder, stamper, oven, conveyor, basket);
        biscuitMachine.Basket.DisplayCookieCount();

        Console.WriteLine($"{Emotes.Tools} Enter operation (N: On, F: Off, P: Pause): ");

        // Simulation loop
        while (true)
        {
            // Check if a key is available
            if (Console.KeyAvailable)
            {
                // Read the pressed key without blocking
                char operation = Console.ReadKey(intercept: true).KeyChar;

                switch (operation)
                {
                    case 'N':
                    case 'n':
                        biscuitMachine.Switch.TurnOn();
                        biscuitMachine.Conveyor.Start();
                        break;

                    case 'F':
                    case 'f':
                        biscuitMachine.Switch.TurnOff();
                        biscuitMachine.Conveyor.Start();
                        break;

                    case 'P':
                    case 'p':
                        biscuitMachine.Switch.Pause();
                        break;

                    default:
                        Console.WriteLine("Invalid operation. Try again.");
                        break;
                }
            }

            if (biscuitMachine.Switch.GetState is MachineOnState)
            {
                var newCookie = biscuitMachine.Extruder.ExtrudeCookie(biscuitMachine.Conveyor);
                Thread.Sleep(1000); // Delay for 1 second
                biscuitMachine.Stamper.StampCookie(newCookie);
                Thread.Sleep(1000); // Delay for 1 second
                biscuitMachine.Oven.BakeCookie(newCookie, biscuitMachine.Conveyor);
                Thread.Sleep(5000); // Delay for 5 seconds (oven baking time)

                biscuitMachine.Basket.DisplayBasketContents();
                biscuitMachine.Basket.DisplayCookieCount();
            }
        }
    }
}
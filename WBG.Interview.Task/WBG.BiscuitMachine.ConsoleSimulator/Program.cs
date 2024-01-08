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
        ICookieFactory cookieFactory = new CookieFactory();
        IStamper stamper = new Stamper();
        IBasket basket = new Basket();
        IConveyor conveyor = new Conveyor(basket);
        IExtruder extruder = new Extruder(cookieFactory, conveyor);
        IOven oven = new Oven(conveyor);
        ISwitch machineSwitch = new Switch(oven);
        IMotor motor = new Motor(conveyor, machineSwitch);

        // Create the biscuit machine using DI
        BiscuitMachineSimulator biscuitMachine = new BiscuitMachineSimulator(machineSwitch, motor, extruder, stamper, oven, conveyor, basket);
        biscuitMachine.Basket.DisplayCookieCount();
        Console.ResetColor();
        var operationString = "Enter operation";
        var operatorCommandKeys = "(N: On, F: Off, P: Pause): ";
        Console.WriteLine($"{Emotes.Tools} {Styles.BoldText(operationString)} {Styles.ItalicText(operatorCommandKeys)}");

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
                        break;

                    case 'F':
                    case 'f':
                        biscuitMachine.Switch.TurnOff();
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
                var newCookie = biscuitMachine.Extruder.ExtrudeCookie();
                biscuitMachine.Stamper.StampCookie(newCookie);
                biscuitMachine.Oven.BakeCookie(newCookie);

                // biscuitMachine.Basket.DisplayBasketContents();
                biscuitMachine.Basket.DisplayCookieCount();
            }
        }
    }
}
using WBG.BiscuitMachine.ConsoleSimulator.Constants;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;
public static class SwitchBox
{
    public static void Control(BiscuitMachineSimulator biscuitMachine)
    {
        // Read the pressed key without blocking
        var operation = Console.ReadKey(intercept: true).KeyChar;

        switch (operation)
        {
            case 'N':
            case 'n':
                biscuitMachine.Switch.TurnOn();
                biscuitMachine.Oven.IsHeatingElementOn = true;
                break;

            case 'F':
            case 'f':
                biscuitMachine.Switch.TurnOff();
                break;

            case 'P':
            case 'p':
                biscuitMachine.Switch.Pause();
                biscuitMachine.Oven.IsHeatingElementOn = true;
                break;

            default:
                Console.WriteLine("Invalid operation. Try again.");
                break;
        }
    }

    public static void DisplayControlMenuOperations()
    {
        var operationString = "Enter operation";
        var operatorCommandKeys = "(N: On, F: Off, P: Pause): ";
        Console.WriteLine($"{Emotes.Tools} {Styles.BoldText(operationString)} {Styles.ItalicText(operatorCommandKeys)}");
    }
}

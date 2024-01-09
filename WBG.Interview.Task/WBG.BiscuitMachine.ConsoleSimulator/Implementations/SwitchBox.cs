namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations;
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
                break;

            default:
                Console.WriteLine("Invalid operation. Try again.");
                break;
        }
    }
}

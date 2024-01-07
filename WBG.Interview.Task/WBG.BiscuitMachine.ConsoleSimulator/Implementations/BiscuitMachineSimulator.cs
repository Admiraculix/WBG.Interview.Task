using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations;

public class BiscuitMachineSimulator
{
    public BiscuitMachineSimulator(
        ISwitch machineSwitch,
        IMotor motor,
        IExtruder extruder,
        IStamper stamper,
        IOven oven,
        IConveyor conveyor,
        IBasket basket)
    {
        Switch = machineSwitch;
        Motor = motor;
        Extruder = extruder;
        Stamper = stamper;
        Oven = oven;
        Conveyor = conveyor;
        Basket = basket;
    }

    public ISwitch Switch { get; }
    public IMotor Motor { get; }
    public IExtruder Extruder { get; }
    public IStamper Stamper { get; }
    public IOven Oven { get; }
    public IConveyor Conveyor { get; }
    public IBasket Basket { get; }
}

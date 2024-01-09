namespace WBG.BiscuitMachine.ConsoleSimulator.Utilities;
public class OSInfo
{
    public string Name { get; }
    public float Version { get; }

    public OSInfo(string name, float version)
    {
        Name = name;
        Version = version;
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}

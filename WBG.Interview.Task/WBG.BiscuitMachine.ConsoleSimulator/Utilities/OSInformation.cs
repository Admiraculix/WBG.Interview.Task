namespace WBG.BiscuitMachine.ConsoleSimulator.Utilities;
public static class OSInformation
{
    public static OSInfo Info { get; set; } = GetWindowsVersionInfo();

    public static OSInfo GetWindowsVersionInfo()
    {
        // Get the operating system version
        Version osVersion = Environment.OSVersion.Version;

        // Check specific version or version range
        if (osVersion.Major == 10 && osVersion.Build >= 22000)
        {
            return new OSInfo("Windows 11", 11); //Only this supports Emojis.
        }
        else if (osVersion.Major == 10 && osVersion.Build < 22000)
        {
            return new OSInfo("Windows 10", 10);
        }
        else if (osVersion.Major == 6 && osVersion.Minor == 3)
        {
            return new OSInfo("Windows 8.1", (float)8.1);
        }
        else if (osVersion.Major == 6 && osVersion.Minor == 2)
        {
            return new OSInfo("Windows 8", 8);
        }

        // Add more checks as needed for other versions
        return null;
    }
}

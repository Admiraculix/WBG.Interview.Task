namespace WBG.BiscuitMachine.ConsoleSimulator.Constants;
public static class Styles
{
    private static string _bold = "\x1b[1m";
    private static string _italic = "\x1b[3m";
    private static string _reset = "\x1b[0m";

    public static string BoldText(string text) => $"{_bold}{text}{_reset}";
    public static string ItalicText(string text) => $"{_italic}{text}{_reset}";
}

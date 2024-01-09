using EmojiToolkit;
using WBG.BiscuitMachine.ConsoleSimulator.Extensions;
using WBG.BiscuitMachine.ConsoleSimulator.Utilities;

namespace WBG.BiscuitMachine.ConsoleSimulator.Constants;
public static class Emotes
{
    public static OSInfo OSInfo { get; set; }

    public static string Cookie => Emoji.Get(":cookie:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Tools => Emoji.Get(":tools:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Play => Emoji.Get(":arrow_forward:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Stop => Emoji.Get(":stop_button:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Pause => Emoji.Get(":pause_button:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Thermometer => Emoji.Get(":thermometer:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Gear => Emoji.Get(":gear:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Chains => Emoji.Get(":chains:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
    public static string Basket => Emoji.Get("::basket:").Raw.ReplaceEmojisWithFallback(OSInfo.Version);
}

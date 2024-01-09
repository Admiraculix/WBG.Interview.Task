using WBG.BiscuitMachine.ConsoleSimulator.Constants;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations;

public class Basket : IBasket
{
    private readonly List<Cookie> _bakedCookies = new List<Cookie>();

    public void AddToBasket(Cookie cookie)
    {
        _bakedCookies.Add(cookie);
    }

    public void DisplayBasketContents()
    {
        Console.WriteLine("Baked Cookies in the Basket:");
        foreach (var cookie in _bakedCookies)
        {
            Console.WriteLine(cookie.ToString());
        }
    }

    public void DisplayCookieCount()
    {
        // Save the current cursor position
        int originalLeft = Console.CursorLeft;
        int originalTop = Console.CursorTop;

        // Move the cursor to the top-right corner
        Console.SetCursorPosition(Console.WindowWidth - 20, 0);

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        // Update and display the cookie count
        Console.Write($"{Emotes.Cookie} Cookie baked: {_bakedCookies.Count}");
        Console.ResetColor();

        // Restore the original cursor position
        Console.SetCursorPosition(originalLeft, originalTop);
    }
}

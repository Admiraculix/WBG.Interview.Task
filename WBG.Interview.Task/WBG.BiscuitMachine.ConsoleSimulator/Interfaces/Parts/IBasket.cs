namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IBasket
{
    void AddToBasket(Cookie cookie);
    void DisplayBasketContents();
    void DisplayCookieCount();
}
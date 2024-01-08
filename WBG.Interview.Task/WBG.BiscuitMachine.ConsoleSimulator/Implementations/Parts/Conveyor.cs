using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Conveyor : IConveyor
{
    private readonly Queue<Cookie> _cookieQueue = new Queue<Cookie>();
    private readonly IBasket _basket;

    public Conveyor(IBasket basket)
    {
        _basket = basket;
    }

    public void Start()
    {
        //TODO: need some logic here!
    }

    public void EnqueueCookie(Cookie cookie)
    {
        _cookieQueue.Enqueue(cookie);
    }

    public void DequeueCookie()
    {
        var cookie = _cookieQueue.Dequeue();
        _basket.AddToBasket(cookie);
    }
}

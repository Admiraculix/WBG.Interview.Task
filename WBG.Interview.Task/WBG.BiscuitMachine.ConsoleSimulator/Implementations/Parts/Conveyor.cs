using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Conveyor : IConveyor
{
    private readonly Queue<Cookie> _cookieQueue = new Queue<Cookie>();
    private readonly IBasket _basket;

    public Queue<Cookie> ConveyorBelt
    {
        get { return _cookieQueue; }
    }

    public Conveyor(IBasket basket)
    {
        _basket = basket;
    }

    public void Start()
    {
        //TODO: need some logic here!
        Console.WriteLine($"START C");
    }

    public void Stop()
    {
        //TODO: need some logic here!
        Console.WriteLine($"STOP C");
    }

    public void Continue()
    {
        if (_cookieQueue.Count > 0)
        {
            Console.WriteLine($"Conveyor belt continues with {_cookieQueue.Count} cookies.");
        }
        else
        {
            Console.WriteLine("Conveyor belt Stop!");
        }
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

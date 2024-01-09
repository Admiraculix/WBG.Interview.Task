using WBG.BiscuitMachine.ConsoleSimulator.Interfaces;
using WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

namespace WBG.BiscuitMachine.ConsoleSimulator.Implementations.Parts;

public class Conveyor : IConveyor
{
    private readonly IBasket _basket;
    private readonly Queue<Cookie> _cookieQueue = new Queue<Cookie>();

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
        Console.WriteLine($"Conveyor belt Start!");
    }

    public void Stop()
    {
        //TODO: need some logic here!
        Console.WriteLine($"Conveyor belt Stop!");
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

    public Cookie DequeueCookie()
    {
        var cookie = _cookieQueue.Dequeue();
        _basket.AddToBasket(cookie);

        return cookie;
    }

    public void ModifyElementAtIndex(int index, string partName, ICookieState state, double thickness = default)
    {
        Cookie[] tempArray = _cookieQueue.ToArray();
        int queueLength = tempArray.Length;

        if (index >= 0 && index < queueLength)
        {
            if (partName.Equals("Stamper"))
            {
                tempArray[index].Thickness -= thickness;
                tempArray[index].State = state;
            }
            if (partName.Equals("Oven"))
            {
                tempArray[index].State = state;
            }

            _cookieQueue.Clear();
            foreach (var obj in tempArray)
            {
                _cookieQueue.Enqueue(obj);
            }
        }
    }
}

namespace WBG.BiscuitMachine.ConsoleSimulator.Interfaces.Parts;

public interface IConveyor
{
    Cookie DequeueCookie();
    void EnqueueCookie(Cookie cookie);
    void Start();
    void Stop();
    void Continue();
    Queue<Cookie> ConveyorBelt { get; }

    void ModifyElementAtIndex(int index, string partName, ICookieState state, double thickness = default);
}
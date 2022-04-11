public class EntityMoveSouthState : IState
{
    public void Enter()
    {
        Console.WriteLine("Start Moving South");
    }

    public void Update()
    {
        Console.WriteLine("Moving South...");
    }

    public void Exit()
    {
        Console.WriteLine("Stop Moving");
    }
}
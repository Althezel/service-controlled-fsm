public class EntityMoveNorthState : IState
{
    public void Enter()
    {
        Console.WriteLine("Start Moving North");
    }

    public void Update()
    {
        Console.WriteLine("Moving North...");
    }

    public void Exit()
    {
        Console.WriteLine("Stop Moving");
    }
}
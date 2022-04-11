public class EntityMoveWestState : IState
{
    public void Enter()
    {
        Console.WriteLine("Start Moving West");
    }

    public void Update()
    {
        Console.WriteLine("Moving West...");
    }

    public void Exit()
    {
        Console.WriteLine("Stop Moving");
    }
}
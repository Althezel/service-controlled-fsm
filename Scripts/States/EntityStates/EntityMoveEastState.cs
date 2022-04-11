public class EntityMoveEastState : IState
{
    public void Enter()
    {
        Console.WriteLine("Start Moving East");
    }

    public void Update()
    {
        Console.WriteLine("Moving East...");
    }

    public void Exit()
    {
        Console.WriteLine("Stop Moving");
    }
}
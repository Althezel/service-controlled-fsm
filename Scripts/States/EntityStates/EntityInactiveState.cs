public class EntityInactiveState : IState
{
    public void Enter()
    {
        Console.WriteLine("Enter Inactive State");
    }

    public void Update()
    {
        Console.WriteLine("Wait For Updates");
    }

    public void Exit()
    {
        Console.WriteLine("Exit Inactive State");
    }
}
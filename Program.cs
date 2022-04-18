namespace FSM
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveableEntity e = new MoveableEntity(
                new EntityStateMachine(),
                new Location(0, 0, Rotation.North)
            );

            e.HandleInput(EntityAction.MoveEast);

            int count = 10;

            while(count > 0)
            {
                e.Update();
                count--;
            }
        }
    }
}
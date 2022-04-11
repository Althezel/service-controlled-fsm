namespace FSM
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityAction[] testActions = new EntityAction[] {
                EntityAction.MoveEast,
                EntityAction.MoveNorth,
                EntityAction.MoveWest,
                EntityAction.MoveSouth
            };

            MoveableEntity e = new MoveableEntity(
                new EntityStateMachine(new EntityInactiveState()),
                new Location(0, 0, Rotation.North),
                testActions
            );

            e.ProcessActions();
        }
    }
}
public class MoveableEntity : IEntity<EntityAction>
{
    public IStateMachine<EntityAction> FSM { get; set; }
    public Location Location { get; set; }
    public EntityAction[] Actions;

    public MoveableEntity(IStateMachine<EntityAction> fsm, Location location, EntityAction[] actions)
    {
        FSM = fsm;
        Location = location;
        Actions = actions;
    }

    public void RotateEntity(EntityAction action)
    {
        switch (action)
        {
            case EntityAction.MoveNorth:
                Location = new Location(Location.X, Location.Y, Rotation.North);
                break;
            case EntityAction.MoveEast:
                Location = new Location(Location.X, Location.Y, Rotation.East);
                break;
            case EntityAction.MoveSouth:
                Location = new Location(Location.X, Location.Y, Rotation.South);
                break;
            case EntityAction.MoveWest:
                Location = new Location(Location.X, Location.Y, Rotation.West);
                break;
            default:
                break;
        }
    }

    public void ProcessActions()
    {
        foreach (EntityAction action in Actions)
        {
            RotateEntity(action);
            IResponse? response = FSM.ProcessAction(action, new MovementRequest(Location));

            if (response is MovementResponse res && res.Allow)
            {
                Location = new Location(res.NextLocation.X, res.NextLocation.Y, res.NextLocation.R);
                // Console.WriteLine($"X: {Location.X}, Y: {Location.Y}, R: {Location.RKey()}");
                FSM.ProcessAction(EntityAction.Inactive, null);
            }
        }
    }
}
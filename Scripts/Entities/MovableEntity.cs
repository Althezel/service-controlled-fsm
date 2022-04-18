public class MoveableEntity : IEntity<EntityAction>
{
    private IState currentState;

    public IStateMachine<EntityAction> FSM { get; set; }
    public Location Location { get; set; }
    public Queue<EntityAction> Actions = new Queue<EntityAction>();
    public IState CurrentState
    { 
        get
        {
            return currentState;
        }

        set
        {
            currentState.Exit();
            currentState = value;
            currentState.Enter();
        } 
    }

    public MoveableEntity(IStateMachine<EntityAction> fsm, Location location)
    {
        FSM = fsm;
        Location = location;
        currentState = new EntityInactiveState();
        currentState.Enter();
    }

    public void Update()
    {
        CurrentState.Update();
        if (Actions.Count > 0)
        {
            SendRequest(Actions.Dequeue());
        }
    }

    public void SendRequest(EntityAction action)
    {
        IResponse? response = null;

        switch (action)
        {
            case EntityAction.MoveNorth:
                response = FSM.ProcessAction(
                    action,
                    new MovementRequest(
                        new Location(
                            Location.X,
                            Location.Y,
                            Rotation.North
                        ),
                        FSM.GetNextState(CurrentState, action)
                    ));
                break;
            case EntityAction.MoveEast:
                response = FSM.ProcessAction(
                    action,
                    new MovementRequest(
                        new Location(
                            Location.X,
                            Location.Y,
                            Rotation.East
                        ),
                        FSM.GetNextState(CurrentState, action)
                    ));
                break;
            case EntityAction.MoveSouth:
                response = FSM.ProcessAction(
                    action,
                    new MovementRequest(
                        new Location(
                            Location.X,
                            Location.Y,
                            Rotation.South
                        ),
                        FSM.GetNextState(CurrentState, action)
                    ));
                break;
            case EntityAction.MoveWest:
                response = FSM.ProcessAction(
                    action,
                    new MovementRequest(
                        new Location(
                            Location.X,
                            Location.Y,
                            Rotation.West
                        ),
                        FSM.GetNextState(CurrentState, action)
                    ));
                break;
            case EntityAction.Inactive:
                response = FSM.ProcessAction(
                    action,
                    new InactiveRequest(
                        FSM.GetNextState(CurrentState, action)
                    )
                );
                break;
            default:
                break;
        }

        if (response != null)
        {
            ProcessResponse(response);
        }
    }

    public void ProcessResponse(IResponse response)
    {
        CurrentState = response.NextState;

        if (response is MovementResponse moveResponse)
        {
            Actions.Enqueue(EntityAction.Inactive);
            Location = new Location(moveResponse.NextLocation.X, moveResponse.NextLocation.Y, moveResponse.NextLocation.R);
            // Console.WriteLine($"X: {Location.X}, Y: {Location.Y}, R: {Location.RKey()}");
        }
    }

    public void HandleInput(EntityAction input)
    {
        Actions.Enqueue(input);
    }
}
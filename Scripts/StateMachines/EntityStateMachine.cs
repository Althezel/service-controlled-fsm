public enum EntityAction
{
    Inactive,
    MoveNorth,
    MoveEast,
    MoveSouth,
    MoveWest,
}

public class EntityStateMachine : IStateMachine<EntityAction>
{
    private MovementService MService = new MovementService();
    private IState currentState;
    public IState CurrentState
    {
        get { return currentState; }
    }

    public void SetState(IState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public EntityStateMachine(IState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public IResponse? ProcessAction(EntityAction action, IRequest? request)
    {
        switch (action)
        {            
            case EntityAction.MoveNorth:
            case EntityAction.MoveEast:
            case EntityAction.MoveSouth:
            case EntityAction.MoveWest:
                if (request is MovementRequest req)
                {
                    IResponse response = MService.ProcessRequest(req);

                    if (response is MovementResponse res)
                    {
                        if (res.Allow)
                        {
                            SetState(ChangeState(currentState, action));
                            currentState.Update();
                        }

                        return res;
                    }
                }
                
                return null;
            case EntityAction.Inactive:
                SetState(ChangeState(currentState, action));
                currentState.Update();
                return null;
            default:
                return null;
        }
    }

    public IState ChangeState(IState current, EntityAction action) =>
        (current, action) switch
        {
            (EntityInactiveState, EntityAction.MoveNorth)   => new EntityMoveNorthState(),
            (EntityInactiveState, EntityAction.MoveEast)    => new EntityMoveEastState(),
            (EntityInactiveState, EntityAction.MoveSouth)   => new EntityMoveSouthState(),
            (EntityInactiveState, EntityAction.MoveWest)    => new EntityMoveWestState(),
            (EntityInactiveState, EntityAction.Inactive)    => new EntityInactiveState(),
            (EntityMoveNorthState, EntityAction.Inactive)   => new EntityInactiveState(),
            (EntityMoveEastState, EntityAction.Inactive)    => new EntityInactiveState(),
            (EntityMoveSouthState, EntityAction.Inactive)   => new EntityInactiveState(),
            (EntityMoveWestState, EntityAction.Inactive)    => new EntityInactiveState(),
            _                                               => throw new NotSupportedException($"{current} has no transition on {action}"),
        };
}
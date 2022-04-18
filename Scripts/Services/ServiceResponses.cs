public interface IResponse
{
    public IState NextState { get; }
}

public struct MovementResponse : IResponse
{
    public IState NextState { get; }
    public Location NextLocation { get; }

    public MovementResponse(Location nextLocation, IState nextState)
    {
        NextState = nextState;
        NextLocation = nextLocation;
    }
}

public struct InactiveResponse : IResponse
{
    public IState NextState { get; }

    public InactiveResponse(IState nextState)
    {
        NextState = nextState;
    }
}
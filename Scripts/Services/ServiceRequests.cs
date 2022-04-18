public interface IRequest
{
    public IState NextState { get; }
}

public struct MovementRequest : IRequest
{
    public IState NextState { get; }
    public Location CurrentLocation { get; }

    public MovementRequest(Location currentLocation, IState nextState)
    {
        NextState = nextState;
        CurrentLocation = currentLocation;
    }
}

public struct InactiveRequest : IRequest
{
    public IState NextState { get; }

    public InactiveRequest(IState nextState)
    {
        NextState = nextState;
    }
}
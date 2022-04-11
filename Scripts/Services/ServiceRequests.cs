public interface IRequest {}

public struct MovementRequest : IRequest
{
    public MovementRequest(Location currentLocation)
    {
        CurrentLocation = currentLocation;
    }

    public Location CurrentLocation { get; }
}
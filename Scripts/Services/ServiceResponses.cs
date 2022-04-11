public interface IResponse {}

public struct MovementResponse : IResponse
{
    public MovementResponse(bool allow, Location nextLocation)
    {
        Allow = allow;
        NextLocation = nextLocation;
    }

    public bool Allow { get; }
    public Location NextLocation { get; }
}
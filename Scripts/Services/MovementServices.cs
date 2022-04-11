public class MovementService : IService
{
    public const int MAP_SIZE = 2;
    public int[,] Map { get; private set; }

    public MovementService() {
        Map = new int[MAP_SIZE, MAP_SIZE] { { 0, 0 }, { 0, 0 } };
        Map[0,0] = 1;
    }

    public IResponse ProcessRequest(IRequest request)
    {
        if (request is MovementRequest r)
        {
            int currentX = r.CurrentLocation.X;
            int currentY = r.CurrentLocation.Y;
            int requestedX = currentX;
            int requestedY = currentY;

            switch (r.CurrentLocation.R)
            {
                case Rotation.North:
                    requestedY += 1;
                    break;
                case Rotation.East:
                    requestedX += 1;
                    break;
                case Rotation.South:
                    requestedY -= 1;
                    break;
                case Rotation.West:
                    requestedX -= 1;
                    break;
                default:
                    throw new NotSupportedException($"{r.CurrentLocation.RKey()} not supported in MovementService.ProcessRequest");
            }

            if (
                requestedY >= 0
                && requestedX >= 0
                && requestedY < MAP_SIZE
                && requestedX < MAP_SIZE
                && Map[requestedX, requestedY] == 0
            ) {
                Map[currentX, currentY] = 0;
                Map[requestedX, requestedY] = 1;
                return new MovementResponse(
                    true,
                    new Location(
                        requestedX,
                        requestedY,
                        r.CurrentLocation.R
                    )
                );
            } else {
                return new MovementResponse(
                    false,
                    new Location(
                        r.CurrentLocation.X,
                        r.CurrentLocation.Y,
                        r.CurrentLocation.R
                    )
                );
            }
        } else {
            return new MovementResponse(
                false,
                new Location(
                    0,
                    0,
                    Rotation.North
                )
            );
        }
    }
}
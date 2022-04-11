public enum Rotation
{
    North, East, South, West
}

public struct Location
{
    public Location (int x, int y, Rotation r)
    {
        X = x;
        Y = y;
        R = r;
    }

    public int X { get; }
    public int Y { get; }
    public Rotation R { get; }
    public string RKey() => this.R switch
    {
        Rotation.North => "North",
        Rotation.East => "East",
        Rotation.South => "South",
        Rotation.West => "West",
        _ => throw new NotSupportedException($"{this.R} is not support by Location Type"),
    };
}
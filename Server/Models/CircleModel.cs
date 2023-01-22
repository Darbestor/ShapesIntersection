namespace Server.Models;

public class CircleModel : ShapeModel
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Radius { get; set; }

    public override string ToString()
    {
        return $"Circle: Center({X}, {Y}); Radius {Radius}";
    }
}
namespace Server.Models;

public class TriangleModel : ShapeModel
{
    public Point Point1 { get; set; }
    public Point Point2 { get; set; }
    public Point Point3 { get; set; }

    public override string ToString()
    {
        return $"Triangle: P1({Point1.X}, {Point1.Y}); P2({Point2.X}, {Point2.Y}); P3({Point3.X}, {Point3.Y})";
    }
}
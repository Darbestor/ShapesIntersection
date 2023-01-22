namespace WebApp.Models;

public class RectangleModel : ShapeModel
{
    public float Top { get; set; }
    public float Left { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    public override string ToString()
    {
        return $"Rectangle: Top {Top}; Left {Left}; Width {Width}; Height {Height}";
    }
}
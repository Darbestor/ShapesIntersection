namespace WebApp.Models;

public class LineModel : ShapeModel
{
    public float X1 { get; set; }
    public float X2 { get; set; }
    public float Y1 { get; set; }
    public float Y2 { get; set; }

    public override string ToString()
    {
        return $"Line: ({X1}, {Y1}); ({X2}, {Y2})";
    }
}
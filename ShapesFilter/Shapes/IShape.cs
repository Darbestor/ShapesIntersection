namespace ShapesFilter.Shapes
{
    public interface IShape
    {
        float Area { get; }
        ShapeType ShapeType { get; }
    }
}
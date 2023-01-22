namespace ShapesFilter.Shapes
{
    /// <summary>
    /// Base shape
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Shape area
        /// </summary>
        float Area { get; }

        /// <summary>
        /// Type of shape
        /// </summary>
        ShapeType ShapeType { get; }
    }
}
using System.Text.Json;
using Server.Models;

namespace Server.Services;

public class ShapesSessionRepository
{
    private const string ShapesKey = "shapes";
    private readonly ISession? _session;

    public ShapesSessionRepository(IHttpContextAccessor contextAccessor)
    {
        _session = contextAccessor.HttpContext?.Session;
    }

    public void SetShapes(List<ShapeModel> shapeModels)
    {
        var serialized = JsonSerializer.Serialize(shapeModels);
        _session.SetString(ShapesKey, serialized);
    }

    public void ClearShapes()
    {
        _session.Remove(ShapesKey);
    }

    public List<ShapeModel> GetShapes()
    {
        var shapeModels = _session.TryGetValue(ShapesKey, out var raw)
            ? JsonSerializer.Deserialize<List<ShapeModel>>(raw)!
            : new List<ShapeModel>();
        return shapeModels;
    }
}
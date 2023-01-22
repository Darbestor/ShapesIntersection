using System.Text.Json.Serialization;

namespace WebApp.Models;

[JsonDerivedType(typeof(LineModel), 1)]
[JsonDerivedType(typeof(CircleModel), 2)]
[JsonDerivedType(typeof(RectangleModel), 3)]
[JsonDerivedType(typeof(TriangleModel), 4)]
public class ShapeModel
{
}
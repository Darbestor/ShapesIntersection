using System;
using ShapesFilter.DI;
using ShapesFilter.Shapes;

internal class Program
{
    // Main Method
    public static void Main(string[] args)
    {
        var line = new Line(0, 0, 10, 10);
        var line2 = new Line(20, 20, 11, 11);
        var strategySelector = StrategySelector.GetStrategy(line.ShapeType, line2.ShapeType);
        var test = strategySelector.Intersect(line, line2);

        Console.WriteLine("Main Method");
    }
}
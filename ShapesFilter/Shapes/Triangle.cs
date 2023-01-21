﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapesFilter.Shapes
{
    public class Triangle : Polygon
    {
        public Triangle(params PointF[] vertices) : base(vertices)
        {
            if (vertices.Length != 3) throw new ArgumentException("Triangle must have 3 vertices");
            AABB = new BoundingBox(vertices);
            Area = GetArea();
        }

        public Triangle(IEnumerable<PointF> boundaries) : this(boundaries.ToArray())
        {
        }

        public override BoundingBox AABB { get; }
        public override float Area { get; }

        private float GetArea()
        {
            var p1 = Vertices[0];
            var p2 = Vertices[1];
            var p3 = Vertices[2];
            return 0.5f * MathF.Abs((p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y));
        }
    }
}
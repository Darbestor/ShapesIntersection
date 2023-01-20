﻿using System;

namespace ShapesFilter.Shapes
{
    public class PointF: IComparable<PointF>
    {
        public float X { get;}
        public float Y { get;}

        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is PointF other)
            {
                return X.Equals(other.X) && Y.Equals(other.Y);
            }
            
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public int CompareTo(PointF other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var xComparison = X.CompareTo(other.X);
            if (xComparison != 0) return xComparison;
            return Y.CompareTo(other.Y);
        }
    }
}
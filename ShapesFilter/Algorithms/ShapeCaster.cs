using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    internal class ShapeCaster<S1, S2> where S1 : IShape
        where S2 : IShape
    {
        internal ShapeCaster(IShape shape1, IShape shape2)
        {
            if (shape1 is S1 sh1 && shape2 is S2 sh2)
            {
                Shape1 = sh1;
                Shape2 = sh2;
            }
            else if (shape2 is S1 s1 && shape1 is S2 s2)
            {
                Shape1 = s1;
                Shape2 = s2;
            }
            else
            {
                throw new ArgumentException("Wrong shapes");
            }
        }

        public S1 Shape1 { get; set; }
        public S2 Shape2 { get; set; }
    }
}
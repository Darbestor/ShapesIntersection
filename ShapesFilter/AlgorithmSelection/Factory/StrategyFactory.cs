using System.Collections.Generic;
using System.Linq;
using ShapesFilter.Algorithms;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Factory
{
    /// <summary>
    ///     Algorithm factory with intersection strategies for specified shape
    /// </summary>
    public abstract class AlgorithmFactory
    {
        protected List<IntersectStrategy> _strategies;

        protected AlgorithmFactory()
        {
            _strategies = new List<IntersectStrategy>();
        }

        /// <summary>
        ///     Add new strategy
        /// </summary>
        /// <param name="strategy"></param>
        public void AddStrategy(IntersectStrategy strategy)
        {
            _strategies.Add(strategy);
        }

        /// <summary>
        ///     Return strategy if factory has it for specified types
        /// </summary>
        /// <param name="shapeType1">shape type</param>
        /// <param name="shapeType2">shape type</param>
        /// <param name="algorithm">out param. Intersection algorithm</param>
        /// <returns>true if algorithm found</returns>
        public virtual bool TryGetStrategy(ShapeType shapeType1, ShapeType shapeType2,
            out IIntersectAlgorithm algorithm)
        {
            var candidate = _strategies.FirstOrDefault(x => x.ValidStrategy(shapeType2));
            if (candidate == null)
            {
                algorithm = null;
                return false;
            }

            algorithm = candidate.Algorithm;
            return true;
        }
    }
}
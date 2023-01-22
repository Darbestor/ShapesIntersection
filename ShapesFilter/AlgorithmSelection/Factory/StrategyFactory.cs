using System.Collections.Generic;
using System.Linq;
using ShapesFilter.Algorithms;
using ShapesFilter.AlgorithmSelection.Strategies;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Factory
{
    public abstract class AlgorithmFactory
    {
        protected List<IntersectStrategy> _strategies;

        protected AlgorithmFactory()
        {
            _strategies = new List<IntersectStrategy>();
        }

        public void AddStrategy(IntersectStrategy strategy)
        {
            _strategies.Add(strategy);
        }

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
using System;

namespace Dws.CodePuzzle.Core
{
    public abstract class RegularPolygonDefinition : IRegularPolygonDefinition
    {
        /// <summary>
        /// Gets or sets the length of each of the sides of the polygon.
        /// </summary>
        public float SideLength { get; set; }

        /// <summary>
        /// Gets the number of sides on this polygon.
        /// </summary>
        public abstract int Sides { get; }

        /// <summary>
        /// Gets the radius of the polygon.
        /// </summary>
        public float Radius
        {
            get
            {
                var radius = SideLength;
                var segmentAngle = (360.0f / Sides);
                var halfSegmentAngle = segmentAngle / 2;
                var halfSegmentAngleRadians = halfSegmentAngle * (Math.PI / 180.0f);

                radius = (float)((radius / 2.0f) / Math.Sin(halfSegmentAngleRadians));

                return radius;
            }
        }
    }
}

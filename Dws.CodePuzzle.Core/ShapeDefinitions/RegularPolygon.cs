using System;

namespace Dws.CodePuzzle.Core
{
    public abstract class RegularPolygon : IRegularPolygonDefinition
    {
        public float SideLength { get; set; }

        public abstract int Sides { get; }

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

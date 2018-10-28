using System;
using System.Collections.Generic;
using System.Text;

namespace Dws.CodePuzzle.Core.ShapeDefinitions
{
    

    public sealed class EquilateralTriangleDefinition : IWidthHeightShapeDefinition
    {
        public float Width { get; set; }

        public float Height { get => Width * 0.86602540f; set => Width = value / 0.86602540f; }

    }
    public sealed class IsoscelesTriangleDefinition : IWidthHeightShapeDefinition
    {
        public float Width { get; set; }

        public float Height { get; set; }
    }
    public sealed class ScaleneTriangleDefinition : IWidthHeightShapeDefinition
    {
        public float Width { get; set; }

        public float Height { get; set; }

    }
}

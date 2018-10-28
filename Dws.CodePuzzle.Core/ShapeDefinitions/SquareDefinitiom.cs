namespace Dws.CodePuzzle.Core
{
    public class SquareDefinition : IRegularPolygonDefinition
    {
        public float SideLength { get; set; }

        public float Width { get => SideLength; }

        public float Height { get => SideLength; }

        public int Sides => 4;
    }

}
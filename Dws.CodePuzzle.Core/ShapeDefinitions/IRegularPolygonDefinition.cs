namespace Dws.CodePuzzle.Core
{
    public interface  IRegularPolygonDefinition: IShapeDefinition
    {
        float SideLength { get; }
        int Sides { get; }
    }

}
namespace Dws.CodePuzzle.Core
{
    public interface IShapeDefinition
    {

    }

    public interface IWidthHeightShapeDefinition : IShapeDefinition
    {
        float Width { get;  }

        float Height { get;  }
    }

}
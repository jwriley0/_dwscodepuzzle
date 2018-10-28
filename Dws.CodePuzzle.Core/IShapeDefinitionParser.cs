namespace Dws.CodePuzzle.Core
{
    /// <summary>
    /// Interface for services that interpret user entry and provide a shape definition.
    /// </summary>
    public interface IShapeDefinitionParser
    {
        /// <summary>
        /// Interprets the specified command to produce a shape definition that can be used to draw the specified shape.
        /// </summary>
        /// <param name="command">The user's natural language command to define a shape.</param>
        /// <returns>A shape definition based on the user test entered.</returns>
        IShapeDefinition Parse(string command);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Dws.CodePuzzle.Core
{
    public sealed class ShapeDefinitionResolutionService : IShapeDefinitionResolutionService
    {
        private readonly IDictionary<string, Type> ShapeDefinitionTypes = GetShapeDefinitionTypes();

        private static IDictionary<string, Type> GetShapeDefinitionTypes()
        {
            var shapeDefinitions = typeof(IShapeDefinition).Assembly
                .GetExportedTypes().Where(i => typeof(IShapeDefinition).IsAssignableFrom(i) && i.IsClass && i.IsAbstract == false);

            return shapeDefinitions.ToDictionary(i => i.Name.Replace("Definition", string.Empty).ToLower());
        }

        public IShapeDefinition GetShapeDefinition(string shapeName)
        {
            var shapeNameKey = shapeName.ToLower().Replace(" ", string.Empty).ToLower();

            if (ShapeDefinitionTypes.ContainsKey(shapeNameKey) == false)
                throw new InvalidShapeException($"\"{shapeName}\" is not valid a valid shape.");

            var type = ShapeDefinitionTypes[shapeNameKey];
            var item = Activator.CreateInstance(type);

            return item as IShapeDefinition;
        }
    }
}

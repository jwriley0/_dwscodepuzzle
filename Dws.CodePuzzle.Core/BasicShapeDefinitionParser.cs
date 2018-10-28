using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Dws.CodePuzzle.Core
{

    public interface IShapeDefinitionResolutionService
    {
        IShapeDefinition GetShapeDefinition(string name);
    }

    public class ShapeDefinitionResolutionService : IShapeDefinitionResolutionService
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

    public class BasicShapeDefinitionParser : IShapeDefinitionParser
    {
        static readonly Regex Regex = new Regex(@"draw (a|an) (?<shape>[a-z]+( [a-z]+)?)? with (a )?(?<dim1>[a-z]+( [a-z]+)?) of (?<val1>[0-9]+)( and (a )?(?<dim2>[a-z]+( [a-z]+)?) of (?<val2>[0-9]+))?", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        IShapeDefinitionResolutionService shapeDefinitionResolutionService;

        public BasicShapeDefinitionParser(IShapeDefinitionResolutionService shapeDefinitionResolutionService)
        {
            this.shapeDefinitionResolutionService = shapeDefinitionResolutionService;
        }

        public IShapeDefinition Parse(string command)
        {
            var match = Regex.Match(command);

            if (!match.Success)
                throw new InvalidFormatException("The command entered in not in a valid format.");

            var shapeName = match.Groups["shape"].Value;

            try
            {
                var item = shapeDefinitionResolutionService.GetShapeDefinition(shapeName);

                var propertyName = match.Groups["dim1"].Value;
                var enteredValue = match.Groups["val1"].Value;

                SetPropertyValue(item, propertyName, enteredValue);

                propertyName = match.Groups["dim2"].Value;
                enteredValue = match.Groups["val2"].Value;

                if (propertyName != string.Empty)
                    SetPropertyValue(item, propertyName, enteredValue);

                return item as IShapeDefinition;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        private static PropertyInfo SetPropertyValue(object item, string propertyName, string enteredValue)
        {
            PropertyInfo property = GetShapeProperty(item.GetType(), propertyName.Replace(" ", ""));
            if (property == null)
                throw new InvalidPropertyNameException($"The property \"{propertyName}\" does not exist on shape.");

            float value;

            if (!float.TryParse(enteredValue, out value))
                throw new InvalidValueException($"The value \"{enteredValue}\" is not valid for property \"{property.Name}\".");

            try
            {
                property.SetValue(item, value);
            }
            catch (System.ArgumentException)
            {
                throw new InvalidPropertyActionException($"Unable to set property \"{propertyName}\". ");
            }
            return property;
        }

        private static PropertyInfo GetShapeProperty(Type type, string propertyName)
        {
            return type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
        }
    }
}

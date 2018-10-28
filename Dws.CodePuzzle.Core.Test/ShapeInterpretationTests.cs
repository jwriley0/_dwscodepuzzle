using Dws.CodePuzzle.Core.ShapeDefinitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dws.CodePuzzle.Core.Test
{
    [TestClass]
    public class ShapeInterpretationTests
    {
        [TestMethod]
        public void TestCircleInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService()).Parse("draw a circle with a radius of 200");

            Assert.IsInstanceOfType(definition, typeof(CircleDefinition));

            var circle = definition as CircleDefinition;

            Assert.AreEqual(200, circle.Radius);
        }

        [TestMethod]
        public void TestRectangleInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService()).Parse("draw a rectangle with a width of 200 and a height of 300");

            Assert.IsInstanceOfType(definition, typeof(RectangleDefinition));

            var rect = definition as RectangleDefinition;

            Assert.AreEqual(200, rect.Width);
            Assert.AreEqual(300, rect.Height);
        }

        [TestMethod]
        public void TestEquilateralTriangleInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an Equilateral Triangle with a width of 200");

            Assert.IsInstanceOfType(definition, typeof(ShapeDefinitions.EquilateralTriangleDefinition));

            var triangle = definition as EquilateralTriangleDefinition;

            Assert.AreEqual(200, triangle.Width);
            Assert.AreEqual(200 * 0.86602540f, triangle.Height);
        }

        [TestMethod]
        public void TestIsoscelesTriangleInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an Isosceles Triangle with a width of 200 and a height of 400");

            Assert.IsInstanceOfType(definition, typeof(ShapeDefinitions.IsoscelesTriangleDefinition));

            var triangle = definition as IsoscelesTriangleDefinition;

            Assert.AreEqual(200, triangle.Width);
            Assert.AreEqual(400, triangle.Height);
        }
        [TestMethod]
        public void TestScaleneTriangleInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an Scalene Triangle with a width of 200 and a height of 500");

            Assert.IsInstanceOfType(definition, typeof(ShapeDefinitions.ScaleneTriangleDefinition));

            var triangle = definition as ScaleneTriangleDefinition;

            Assert.AreEqual(200, triangle.Width);
            Assert.AreEqual(500, triangle.Height);
        }

        [TestMethod]
        public void TestOvalInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an oval with a width of 200 and a height of 500");

            Assert.IsInstanceOfType(definition, typeof(OvalDefinition));

            var oval = definition as OvalDefinition;

            Assert.AreEqual(200, oval.Width);
            Assert.AreEqual(500, oval.Height);
        }

        [TestMethod]
        public void TestParallelogramInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an Parallelogram with a width of 200 and a height of 500");

            Assert.IsInstanceOfType(definition, typeof(ParallelogramDefinition));

            var parallelogramDefinition = definition as ParallelogramDefinition;

            Assert.AreEqual(200, parallelogramDefinition.Width);
            Assert.AreEqual(500, parallelogramDefinition.Height);
        }

        [TestMethod]
        public void TestHexagonInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an Hexagon with a side length of 200");

            Assert.IsInstanceOfType(definition, typeof(HexagonDefinition));

            var hexagon = definition as HexagonDefinition;

            Assert.AreEqual(6, hexagon.Sides);
            Assert.AreEqual(200, hexagon.SideLength);
        }
        [TestMethod]
        public void TestPentagonInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an pentagon with a side length of 222");

            Assert.IsInstanceOfType(definition, typeof(PentagonDefinition));

            var pentagon = definition as PentagonDefinition;

            Assert.AreEqual(5, pentagon.Sides);
            Assert.AreEqual(222, pentagon.SideLength);
        }
        [TestMethod]
        public void TestHeptagonInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an Heptagon with a side length of 365");

            Assert.IsInstanceOfType(definition, typeof(HeptagonDefinition));

            var pentagon = definition as HeptagonDefinition;

            Assert.AreEqual(7, pentagon.Sides);
            Assert.AreEqual(365, pentagon.SideLength);
        }
        [TestMethod]
        public void TestOctagonInterpretation()
        {
            var definition = new BasicShapeDefinitionParser(new ShapeDefinitionResolutionService())
                .Parse("draw an octagon with a side length of 444");

            Assert.IsInstanceOfType(definition, typeof(OctagonDefinition));

            var pentagon = definition as OctagonDefinition;

            Assert.AreEqual(8, pentagon.Sides);
            Assert.AreEqual(444, pentagon.SideLength);
        }
    }
}

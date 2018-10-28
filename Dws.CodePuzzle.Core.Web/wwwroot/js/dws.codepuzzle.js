(function () {

    var canvas = $('#drawing_canvas')[0];

    // set the width of the drawing canvas to match its container
    $(canvas).attr('width', $(canvas).parent().width());

    $(function () {
        var shape = $('#shape');
        // if there is a shape element containg the shape JSON
        if (shape.length > 0) {

            // parse the shape JSON to get the shape object
            var oShape = JSON.parse(shape.text());

            // get the 2d context for the drawing canvas.
            var ctx = canvas.getContext("2d");

            // get the type name from the object to determine the function to render the shape 
            var typeName = oShape.$type;
            typeName = typeName.substring(0, typeName.indexOf(','));

            var renderer = dws.codepuzzle.renderers[typeName];
            if (renderer == null) {
                // log if no renderer found.
                console.log(typeName);
            }
            else {
                // set the fill and line color.
                ctx.strokeStyle = "#204d74";
                ctx.fillStyle = '#286090';

                // call the render function for the shape.
                renderer(oShape, ctx, { width: canvas.offsetWidth, height: canvas.offsetHeight });
            }
        }

    });


    if (window.dws == null) {

        // create a "namespace" for code puzzle code.
        window.dws = {
            "codepuzzle": {
                "renderers": { 
                }
            }
        };
        
        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.CircleDefinition"] = function (circle, ctx, canvas) {
            var radius = circle.Radius;

            var x = (canvas.width / 2) - (radius);
            var y = (canvas.height / 2) - (radius);

            ctx.beginPath();
            ctx.translate(x, y); // centre the circle in the canvas
            var fullCircle = 2 * Math.PI;            
            ctx.arc(radius, radius, radius, 0, fullCircle);
            ctx.fill();
            ctx.stroke();


        };


        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.OvalDefinition"] = function (oval, ctx, canvas) {
            var radius = oval.Height / 2.0;
            var scale = oval.Width / oval.Height;

            // centre the oval in the canvas
            var x = (canvas.width / 2) - (radius * scale);
            var y = (canvas.height / 2) - (radius);
            ctx.translate(x, y);


            ctx.scale(scale, 1);
            ctx.beginPath();
            ctx.arc(radius, radius, radius, 0, 2 * Math.PI);
            ctx.fill();
            ctx.stroke();

        };

        // Square and Rectangle can share the render method
        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.SquareDefinition"] =
            dws.codepuzzle.renderers["Dws.CodePuzzle.Core.RectangleDefinition"] = function (rectangle, ctx, canvas) {

                var x = (canvas.width - rectangle.Width) / 2;
                var y = (canvas.height - rectangle.Height) / 2;
                ctx.translate(x, y);
                ctx.rect(0, 0, rectangle.Width, rectangle.Height);
                ctx.fill();
                ctx.stroke();

            };


        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.ParallelogramDefinition"] = function (rectangle, ctx, canvas) {
            var slope = 0.33;

            var x = (canvas.width - (rectangle.Width * (1 + slope))) / 2;
            var y = (canvas.height - rectangle.Height) / 2;

            ctx.translate(x, y);
            ctx.moveTo(rectangle.Width * slope, 0);
            ctx.lineTo(rectangle.Width * (1 + slope), 0);
            ctx.lineTo(rectangle.Width, rectangle.Height);
            ctx.lineTo(0, rectangle.Height);
            ctx.lineTo(rectangle.Width * slope, 0);
            ctx.fill();
            ctx.stroke();


        };

        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.ShapeDefinitions.ScaleneTriangleDefinition"] = function (triangle, ctx, canvas) {


            var x = (canvas.width - triangle.Width) / 2;
            var y = (canvas.height - triangle.Height) / 2;
            ctx.translate(x, y);


            ctx.moveTo(triangle.Width * 0.2, 0);
            ctx.lineTo(triangle.Width, triangle.Height);
            ctx.lineTo(0, triangle.Height);
            ctx.lineTo(triangle.Width * 0.2, 0);
            ctx.fill();
            ctx.stroke();


        };


        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.ShapeDefinitions.EquilateralTriangleDefinition"] = function (triangle, ctx, canvas) {


            var x = (canvas.width - triangle.Width) / 2;
            var y = (canvas.height - triangle.Height) / 2;
            ctx.translate(x, y);

            var width = triangle.Width;
            var height = Math.sqrt(3) / 2 * width;

            ctx.moveTo(width / 2.0, 0);
            ctx.lineTo(width, height);
            ctx.lineTo(0, height);
            ctx.lineTo(width / 2.0, 0);
            ctx.fill();
            ctx.stroke();

        };

        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.ShapeDefinitions.IsoscelesTriangleDefinition"] = function (triangle, ctx, canvas) {
            var x = (canvas.width - triangle.Width) / 2;
            var y = (canvas.height - triangle.Height) / 2;
            ctx.translate(x, y);

            ctx.moveTo(triangle.Width / 2.0, 0);
            ctx.lineTo(triangle.Width, triangle.Height);
            ctx.lineTo(0, triangle.Height);
            ctx.lineTo(triangle.Width / 2.0, 0);
            ctx.fill();
            ctx.stroke();

        };


        dws.codepuzzle.renderers["Dws.CodePuzzle.Core.HexagonDefinition"] =
            dws.codepuzzle.renderers["Dws.CodePuzzle.Core.OctagonDefinition"] =
            dws.codepuzzle.renderers["Dws.CodePuzzle.Core.PentagonDefinition"] =
            dws.codepuzzle.renderers["Dws.CodePuzzle.Core.HeptagonDefinition"]
            = function (hexagon, ctx, canvas) {
                var numberOfSides = hexagon.Sides;
                var radius = hexagon.Radius;
                console.log(radius);

                var x = radius;
                var y = radius;
                var rotation = 0;

                // centralise
                var tx = (canvas.width - radius * 2) / 2;
                var ty = (canvas.height - radius * 2) / 2;
                ctx.translate(tx, ty);

                // if it is an odd number then give a bit of a rotation
                if (numberOfSides % 2 > 0) {
                    rotation = ((90.0 / numberOfSides) + 180.0) / 57.42;
                }

                ctx.beginPath();
                ctx.moveTo((x + radius * Math.cos(rotation + 0)), (y + radius * Math.sin(rotation + 0)));

                for (var i = 1; i <= numberOfSides; i += 1) {
                    ctx.lineTo(x + radius * Math.cos(rotation + (i * 2 * Math.PI / numberOfSides)),
                        y + radius * Math.sin(rotation + (i * 2 * Math.PI / numberOfSides)));
                }

                ctx.fill();
                ctx.stroke();
            };

    }

})();
using System;
using Microsoft.AspNetCore.Mvc;
using Dws.CodePuzzle.Core.Web.Models;

namespace Dws.CodePuzzle.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        IShapeDefinitionParser shapeDefinitionParser;

        public HomeController(IShapeDefinitionParser parser)
        {
            this.shapeDefinitionParser = parser;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new IndexViewModel { Command = "" });
        }

        [HttpPost]
        public IActionResult Index(string command)
        {
            IShapeDefinition definition = null;
            string error = null;
            try
            {
                definition = shapeDefinitionParser.Parse(command);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return View("Index", new IndexViewModel
            {
                Command = command,
                Shape = definition,
                Error = error
            });
        }



    }
}

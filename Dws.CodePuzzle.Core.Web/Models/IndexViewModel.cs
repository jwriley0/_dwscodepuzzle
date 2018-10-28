using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dws.CodePuzzle.Core.Web.Models
{
    public class IndexViewModel
    {
        public string Command { get;set;}
        public IShapeDefinition Shape { get; internal set; }
        public string Error { get; internal set; }
    }
}

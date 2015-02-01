//Main Area class, areas work diferently than TOMs, so, yeah, not making it a subclass because reasons

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS13MapGen_Shared
{
    
    /// <summary>
    /// Contains area info, looks like TOM, but it isn't
    /// </summary>
    public class BYONDArea
    {
        public string typePath {get; set;}
        public string name {get; set;}
        public string srcXML { get; set; }
    }
}

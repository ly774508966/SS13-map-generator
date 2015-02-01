using SS13MapGen_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS13MapGen_Shared
{

    /// <summary>
    /// Class that stores a single map tile, because BYOND's map format is bullshit
    /// </summary>
    class mapTile
    {
        /// <summary>
        /// Stores all contents of a specific tile, see line 12 for why this is needed
        /// </summary>
        public List<BYONDInstance> contents = new List<BYONDInstance>();

        /// <summary>
        /// Not sure if this is needed, or will be used at all, safety sake I guess
        /// </summary>
        public int xCoord = 0;

        /// <summary>
        /// Not sure if this is needed, or will be used at all, safety sake I guess
        /// </summary>
        public int yCoord = 0;

        
    }
}

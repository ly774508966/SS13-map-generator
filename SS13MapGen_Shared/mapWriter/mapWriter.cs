//Main map writing class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS13MapGen_Shared
{
    /// <summary>
    /// The big bad main writer, WRITE ALL THE THINGS
    /// </summary>
    class mapWriter
    {
        /// <summary>
        /// This is the big queue that stores the file before writing
        /// </summary>
        public Queue<string> mapData = new Queue<string>();

        /// <summary>
        /// the expected amount of needed letter combinations, to set the length of them, shouldn't be too big of a deal, it's like, 1, 2, or 3, but still
        /// </summary>
        public int expectedLetterCombos = 0;

        /// <summary>
        /// Letter combos used, because DM
        /// </summary>
        public int usedCharCombos = 0;


    }
}

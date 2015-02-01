//Main TOM (/turf, /obj, /mob) instance class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS13MapGen_Shared
{
    /// <summary>
    /// Main object that stores data about an instance, only /turf, /mob, or /obj, /area handled seperately
    /// </summary>
    public class BYONDInstance
    {
        /// <summary>
        /// Stores the path of the tom (see what I did there?).
        /// </summary>
        public string typePath { get; set; } //might not need to make this public, we'll see though

        /// <summary>
        /// Stores all vars that are different than normal, format: $VARNAME = $VARVALUE, varvalue needs to be text, always, it needs to be entered like it would be entered in DM.
        /// </summary>
        public Dictionary<string, string> differentVars { get; set; } //Again, not sure if needs to be public

        /// <summary>
        /// Determines if the instance obj is special, and not directly used in the mapwriter, but more to be decided by the mapwriter, things like AIRLOCK.
        /// </summary>
        public string special { get; set; } //I can place these publicity comments all damn day

        /// <summary>
        /// Name, duh, this is what it shows up as in the instance browser.
        /// </summary>
        public string name { get; set; }//See line 29

        /// <summary>
        /// Stores the XML File uri this instance was loaded from.
        /// </summary>
        public string srcXML { get; set; }
    }
}

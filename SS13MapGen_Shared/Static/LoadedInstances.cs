using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS13MapGen_Shared
{
    /// <summary>
    /// Stores ATOMS currently loaded, so I don't have to snowflake it 6+ times.
    /// </summary>
    public static class loadedInstances
    {
        /// <summary>
        /// Stores current areas.
        /// </summary>
        public static List<BYONDArea> loadedAreas { get; set; }

        /// <summary>
        /// Stores currently loaded TOM Instances.
        /// </summary>
        public static List<BYONDInstance> loadedTOMs { get; set; }

        public static void reloadInstances()
        {
            loadedAreas = new List<BYONDArea>();//Empty the lists.
            loadedTOMs = new List<BYONDInstance>();


            foreach (string areaXMLFile in Config.areaXMLFiles)
            {
                List<BYONDArea> tempArea = mainReader.readAreaXML(areaXMLFile);
                loadedAreas.AddRange(tempArea);//Doing this seperate because else vidual gentoodio will cry, 4noraisins.
            }

            foreach (string instanceXMLFile in Config.instanceXMLFiles)
            {
                List<BYONDInstance> tempInstance = mainReader.readInstanceXML(instanceXMLFile);
                loadedTOMs.AddRange(tempInstance);//Doing this seperate for the same reason as on line 33.
            }


            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace SS13MapGen_Shared
{
    /// <summary>
    /// Class that stores config for the UI & Generator, not using .config file because they're confusing and can't do lists (I think).
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Location of the config file
        /// </summary>
        private static string configLoc = "Data/config/main.xml";
        
        /// <summary>
        /// stores the location of the area XML files XML file (no, that was not an acciedental duplication).
        /// </summary>
        private static string areaLoc = "Data/config/area.xml";

        /// <summary>
        /// Stores all loaded TOM Instances.
        /// </summary>
        private static string instanceLoc = "Data/config/instance.xml";

        /// <summary>
        /// list of all XML files containing area instances, public.
        /// </summary>
        public static List<string> areaXMLFiles { get; set; }

        public static List<string> instanceXMLFiles { get; set; }
        

        /// <summary>
        /// Reload the config file, doesn't use the main XML reader because it'd be to annoying to bridge, I COULD make a class that gets returned by the main reader but that's needlessly complicated.
        /// </summary>
        public static void reloadConfig()
        {
            readMainConfig();
            readAreaConfig();
            readInstanceConfig();
        }

        private static void readInstanceConfig()
        {
            if (!File.Exists(instanceLoc))
            {
                createInstanceConfig();
                return;
            }

            XmlReader reader = XmlReader.Create(instanceLoc);
            instanceXMLFiles = new List<string>();//empty the list

            while (reader.Read())
            {
                string lastName = null;
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        lastName = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (lastName == "instanceXMLFile")
                        {
                            instanceXMLFiles.Add(reader.Value);
                        }
                        break;
                }
            }


        }

        private static void createInstanceConfig()
        {
            return;
        }

        /// <summary>
        /// Reads the area config file, creates it if it didn't exist yet.
        /// </summary>
        private static void readAreaConfig()
        {

            if (!File.Exists(areaLoc))
            {
                createAreaConfig();
                return; //The config file was gonna be the same as the data we already have anyways.
            }
            
            XmlReader reader = XmlReader.Create(areaLoc);

            areaXMLFiles = new List<string>();

            while (reader.Read())//do our general reading stuffs
            {
                string lastName = null;
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        lastName = reader.Name;
                        break;
                    
                    case XmlNodeType.Text:
                        if (lastName == "areaXMLFile")
                        {
                            areaXMLFiles.Add(reader.Value);
                        }
                        break;
                }
            }



        }
        
        /// <summary>
        /// Creates the area config file.
        /// </summary>
        private static void createAreaConfig()
        {
            File.Create(areaLoc);
            XmlWriter writer = XmlWriter.Create(areaLoc);

            writer.WriteStartDocument();
            writer.WriteStartElement("areaXMLFiles");
            foreach (string AreaFile in areaXMLFiles)//Write all the things!
            {
                writer.WriteElementString("areaXMLFile", AreaFile);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();

        }

        /// <summary>
        /// Reads the main config file.
        /// </summary>
        private static void readMainConfig()
        {
            if (!File.Exists(configLoc))
            {
                createMainConfig();
                return;//it's gonna be a default config at this point anyways, no point attempting to read the config now.
            }
            
        }

        /// <summary>
        /// Creates us a new config file, and fills it.
        /// </summary>
        private static void createMainConfig()
        {
            return;
        }
    }
}

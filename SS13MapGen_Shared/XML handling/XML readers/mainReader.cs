using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace SS13MapGen_Shared
{
    /// <summary>
    /// Reads XML files, use the appropriate method for the type you want returned from an XML file.
    /// Not gonna bother with schemas, seriously, if anybody's gonna use invalid XML files, it's their problem.
    /// It's one big class instead of something sensible split up, because I was originally going with schemas, and it would've been better for this to be one big class if I DID use schemas, but I changed my plan and now this is approaching SS13 level sloppiness, fitting, isn't it?
    /// </summary>
    public static class mainReader
    {

        /// <summary>
        /// reads an area XML file
        /// </summary>
        /// <param name="path">
        /// path to the XML file to read
        /// </param>
        /// <returns>
        /// an array of type BYONDarea
        /// </returns>
        public static List<BYONDArea> readAreaXML(string path)
        {

            XmlReader reader = XmlReader.Create(path);
            List<BYONDArea> bufferList = new List<BYONDArea>();
            BYONDArea buffer = null;
            string lastName = null;
            while (reader.Read())
            {
                
                switch (reader.NodeType)
                {
                    
                    case XmlNodeType.Element:
                        if (reader.Name == "area")
                        {
                            if (buffer == null)
                            {
                                buffer = new BYONDArea();
                                buffer.srcXML = path;
                            }
                        }
                        lastName = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        switch (lastName)
                        {
                            case "name":
                                buffer.name = reader.Value;
                                break;
                            case "BYONDPath":
                                buffer.typePath = reader.Value;
                                break;
                            default:
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (buffer != null && reader.Name == "area")
                        {
                            bufferList.Add(buffer);
                            buffer = null;
                        }
                        break;
                    
                    default:
                        break;
                }

            }
            return bufferList;
        }

        /// <summary>
        /// Reads from an instance XML file.
        /// </summary>
        /// <param name="path">Path to the .XML file to be read.</param>
        /// <returns>A list of type BYONDInstance, containing the instances that were contained in the XML file.</returns>
        public static List<BYONDInstance> readInstanceXML(string path)
        {
            XmlReader reader = XmlReader.Create(path);
            List<BYONDInstance> bufferList = new List<BYONDInstance>();
            BYONDInstance buffer = null;
            string lastName = null;
            string bufferedVarName = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "instance")
                        {
                            buffer = new BYONDInstance();
                            buffer.srcXML = path;
                        }
                        lastName = reader.Name;

                        if (reader.Name == "vars")
                        {
                            buffer.differentVars = new Dictionary<string,string>();
                        }

                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == "instance")
                        {
                            bufferList.Add(buffer);
                            buffer = null;
                        }
                        break;
                    case XmlNodeType.Text:
                        switch (lastName)
	                    {
                            case "name":
                                buffer.name = reader.Value; 
                                break;
                            case "path":
                                buffer.typePath = reader.Value;
                                break;
                            case "varName":
                                bufferedVarName = reader.Value;//store the name for now, for easyness sake
                                break;
                            case "varValue":
                                buffer.differentVars.Add(bufferedVarName, reader.Value);
                                bufferedVarName = null;
                                break;
	                    }
                        break;
                }
            }
            return bufferList;
        }
    
    
    }
}

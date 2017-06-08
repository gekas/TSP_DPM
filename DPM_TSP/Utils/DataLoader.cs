using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace DPM_TSP.Utils
{
    public static class DataLoader
    {
        public static Tour GetDataFromFile(string fileName)
        {
            var jsonText = File.ReadAllText(fileName);

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            List<City> oRootObject = new List<City>();

            var deserializedTour = JsonConvert.DeserializeObject<Tour>(jsonText);

            return deserializedTour;
        }

        public static void SaveMeasurementsInXml(List<MeasurementItem> objGraph, string fileName)
        {
            var newXmlDoc = SerializeToXmlDocument(objGraph);

            XmlDocument originalDoc = new XmlDocument();
            using (XmlReader xr = new XmlTextReader(fileName))
            {
                originalDoc.Load(xr);
            }

            foreach (XmlNode measurementNode in newXmlDoc.ChildNodes[1].ChildNodes)
            {
                var nodeToAppend = originalDoc.ImportNode(measurementNode, true);

                bool suchMeasurementAlreadyExist = false;
                foreach (XmlNode node in originalDoc.ChildNodes[1])
                    if (node.Attributes["HashCode"].Value == nodeToAppend.Attributes["HashCode"].Value)
                    {
                        suchMeasurementAlreadyExist = true;
                        break;
                    }

                if (!suchMeasurementAlreadyExist)
                    originalDoc.ChildNodes[1].AppendChild(nodeToAppend);
            }

            originalDoc.Save(fileName);
        }

        public static List<MeasurementItem> LoadFromStatisticDb(string dbFileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<MeasurementItem>));

            XmlDocument originalDoc = new XmlDocument();
            using (XmlReader xr = new XmlTextReader(dbFileName))
            {
                originalDoc.Load(xr);
            }

            var result = DeserializeParams<MeasurementItem>(originalDoc);
            return result;
        }

        private static XmlDocument SerializeToXmlDocument(object input)
        {
            XmlSerializer ser = new XmlSerializer(input.GetType());

            XmlDocument xd = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    xd = new XmlDocument();
                    xd.Load(xtr);
                }
            }

            return xd;
        }

        private static List<T> DeserializeParams<T>(XmlDocument doc)
        {
            var xDoc = XDocument.Parse(doc.OuterXml);

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            XmlReader reader = xDoc.CreateReader();

            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace DPM_TSP.Utils
{
    public class DataLoader
    {
        public static Tour GetDataFromFile(string fileName)
        {
            var jsonText = File.ReadAllText(fileName); 

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            List<City> oRootObject = new List<City>();

            var deserializedTour = JsonConvert.DeserializeObject<Tour>(jsonText);

            return deserializedTour;
        }
    }
}

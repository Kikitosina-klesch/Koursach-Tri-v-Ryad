using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koursach_Tri_v_Ryad
{
    class JsonSaveLoadProgress
    {
        public void SaveFile(List<Player> p)
        {
            JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter("json.txt"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, p);
                }
        }
        public List<Player> LoadFile()
        {
            return JsonConvert.DeserializeObject<List<Player>>
                (File.ReadAllText("json.txt"));
            //return JsonConvert.DeserializeObject<List<imgOBJECT>>
            //    (File.ReadAllText("json.txt"));

        }
    }
}

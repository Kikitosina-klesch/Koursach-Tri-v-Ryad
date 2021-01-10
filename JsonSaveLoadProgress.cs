using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koursach_Tri_v_Ryad
{
    class JsonSaveLoadProgress
    {
        string FileName;

        public void SaveFile(List<Player> p)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            DialogResult dlgres = dlg.ShowDialog();
            JsonSerializer serializer = new JsonSerializer();

            if (dlgres == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, p);
                }
            }
        }
        public List<Player> LoadFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgres = dlg.ShowDialog();


            if (dlgres == System.Windows.Forms.DialogResult.OK)
            {
                FileName = dlg.FileName;
            }

            return JsonConvert.DeserializeObject<List<Player>>
                (File.ReadAllText(FileName));

        }
    }
}

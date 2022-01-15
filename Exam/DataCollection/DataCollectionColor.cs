using Exam.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;

namespace Exam.DataCollection
{
    public class DataCollectionColor : IDataCollection<Color>
    {
        public List<Color> Load()
        {
            List<Color> colors = new List<Color>();

            XmlSerializer formatter = new XmlSerializer(typeof(List<Color>));
            try
            {
                using (FileStream fs = new FileStream("colors.xml", FileMode.Open))
                {
                    colors = (List<Color>)formatter.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            return colors;
        }

        public void Save()
        {
            List<Color> colors = new List<Color>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Color>));
            try
            {
                using (FileStream fs = new FileStream("modification.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, colors);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }
}

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
        public List<Color> colors = new List<Color>();
        public List<Color> Load()
        {
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
            
            XmlSerializer formatter = new XmlSerializer(typeof(List<Color>));
            try
            {
                using (FileStream fs = new FileStream("colors.xml", FileMode.OpenOrCreate))
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

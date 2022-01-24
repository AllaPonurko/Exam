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
    public class DataCollectionModel : IDataCollection<Model>
    {
       public List<Model> models = new List<Model>();
        public List<Model> Load()
        {
           
            XmlSerializer formatter = new XmlSerializer(typeof(List<Model>));
            try
            {
                using (FileStream fs = new FileStream("models.xml", FileMode.Open))
                {
                    models = (List<Model>)formatter.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            return models;
        }

        public void Save()
        {
            
            XmlSerializer formatter = new XmlSerializer(typeof(List<Modification>));
            try
            {
                using (FileStream fs = new FileStream("models.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, models);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }
}

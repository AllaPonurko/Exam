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
    public class DataCollectionModel : IDataCollection<Model_>
    {
       public List<Model_> models = new List<Model_>();
        public List<Model_> Load()
        {
           
            XmlSerializer formatter = new XmlSerializer(typeof(List<Model_>));
            try
            {
                using (FileStream fs = new FileStream("models.xml", FileMode.Open))
                {
                    models = (List<Model_>)formatter.Deserialize(fs);
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

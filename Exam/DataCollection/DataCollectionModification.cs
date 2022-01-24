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
    public class DataCollectionModification : IDataCollection<Modification>
    {
        public List<Modification> modifications = new List<Modification>();
        /// <summary>
        /// выгрузить список модификаций
        /// </summary>
        public List<Modification> Load()
        {
           
            XmlSerializer formatter = new XmlSerializer(typeof(List<Modification>));
            try
            {
                using (FileStream fs = new FileStream("modification.xml", FileMode.Open))
                {
                    modifications = (List<Modification>)formatter.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            return modifications;
        }
        /// <summary>
        /// сохранение списка модификаций
        /// </summary>
        public void Save()
        {
            
            XmlSerializer formatter = new XmlSerializer(typeof(List<Modification>));
            try
            {
                using (FileStream fs = new FileStream("modification.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, modifications);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }


        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entities
{
    public class DBContext
    {
        public List<Model> Models { get; set; }
        public DBContext()
        {
            Models = new List<Model>();
            Seed();
        }
        public void Seed()
        {
            Color Red = new Color();
            Color Black = new Color();
            Color Blue = new Color();
            Modification YarisElegant = new Modification();
            YarisElegant.colors.Add(Red);
            YarisElegant.colors.Add(Black);
            YarisElegant.colors.Add(Black);

        }
        public List<Model> SeachByColor(Color color)
        {
            return;
        }
    }
}

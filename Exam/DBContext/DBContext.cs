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
            Model Yaris = new Model() { Name = "Yaris" };
            Color Red = new Color();
            Color Black = new Color();
            Color Blue = new Color();
            Modification YarisElegant = new Modification();
            Model LandCruiser = new Model() { Name = "Land Cruiser" };
            YarisElegant.colors.Add(Red);
            YarisElegant.colors.Add(Black);
            YarisElegant.colors.Add(Blue);
            Yaris.modifications.Add(YarisElegant);
            Color White = new Color();
            Color DarkGrey = new Color();
            Modification LandCruiserPremium = new Modification();
            LandCruiserPremium.colors.Add(White);
            LandCruiserPremium.colors.Add(DarkGrey);
            LandCruiserPremium.colors.Add(Black);
            Models.Add(Yaris);
            Models.Add(LandCruiser);
        }
        public IEnumerable<Model> SeachByColor(Color color)
        {
            return
            from model in Models
            from modification in model.modifications
            from _color in modification.colors
            where color.Name == SeachColor
            select model;

        }
        public void Echo()
        {

        }
    }
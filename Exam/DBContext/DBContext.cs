using Exam.DataCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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
            Color Red = new Color() { Name = "Red" };
            Color Black = new Color() { Name = "Black" };
            Color Blue = new Color() { Name = "Blue" };
            Modification YarisElegant = new Modification() { Name = "Elegant" };
            Model LandCruiser = new Model() { Name = "Land Cruiser" };
            YarisElegant.colors.Add(Red);
            YarisElegant.colors.Add(Black);
            YarisElegant.colors.Add(Blue);
            Yaris.modifications.Add(YarisElegant);
            Color White = new Color() { Name = "White" };
            Color DarkGrey = new Color() { Name = "DarkGrey" };
            Modification LandCruiserPremium = new Modification() { Name = "Premium" };
            LandCruiser.modifications.Add(LandCruiserPremium);
            Modification LandCruiserPrado = new Modification() { Name = "Prado" };
            LandCruiser.modifications.Add(LandCruiserPrado);
            LandCruiserPrado.colors.Add(White);
            LandCruiserPrado.colors.Add(Blue);
            LandCruiserPremium.colors.Add(White);
            LandCruiserPremium.colors.Add(DarkGrey);
            LandCruiserPremium.colors.Add(Black);
            Models.Add(Yaris);
            Models.Add(LandCruiser);
            DataCollectionColor collectionColor = new DataCollectionColor();
            collectionColor.colors.Add(Red);
            collectionColor.colors.Add(Black);
            collectionColor.colors.Add(White);
            collectionColor.colors.Add(Blue);
            collectionColor.colors.Add(DarkGrey);
            collectionColor.Save();
            DataCollectionModel collectionModel = new DataCollectionModel();
            collectionModel.models = Models;
            collectionModel.Save();
            DataCollectionModification collectionModification = new DataCollectionModification();
            collectionModification.modifications.Add(YarisElegant);
            collectionModification.modifications.Add(LandCruiserPremium);
            collectionModification.modifications.Add(LandCruiserPrado);
            collectionModification.Save();
        }
        public IEnumerable<Model> SeachByColor(string ColorName)
        {
            return
            from model in Models
            from modification in model.modifications
            from _color in modification.colors
            where _color.Name == ColorName
            select model;

        }
        public IEnumerable<Modification> _SeachByColor(string ColorName)
        {
                return
            from model in Models
            from modification in model.modifications
            from _color in modification.colors
            where _color.Name == ColorName
            select modification;
        }
        
        public string SeachColor()
        {
            string number = ReadLine();
            switch (number)
            { 
                case "1": return "Red"; 
                case "2": return "Black";
                case "3": return "White";
                case "4": return "Blue"; 
                case "5": return "DarkGrey";
                default:                                     
                    return null;
            }
        }
        public void ChoiceColor()
        {
            WriteLine("Выберите цвет:\n1 - Red\n2 - Black\n3 - White\n4 - Blue\n5 - DarkGrey");
        }
        public void Print()
        {
            DBContext context = new DBContext();
            foreach (var item in context.Models)
            {
                WriteLine($"@@@@@@@@@@@@@@@@@@@@@\n" + $"Модель:\t" + item.
                    ToString());
                {
                    foreach (var item_ in item.modifications)
                    {
                        WriteLine($"Модификация:\t" + item_.ToString());
                        foreach (var _item in item_.colors)
                        {
                            WriteLine($"Доступный цвет:\t" + _item.ToString());

                        }
                    }
                }
                WriteLine($"@@@@@@@@@@@@@@@@@@@@@");
            }
        }
    }
}
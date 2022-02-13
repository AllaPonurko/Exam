using Exam.DataCollection;
using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

using static System.Console;

namespace Exam
{
    public class MyDBContext:DbContext
    {
        public List<Model_> Models { get; set; }
        public DbSet<Base> bases { get; set; }
        public DbSet<Color> colores{ get; set; }
        public DbSet<Model_> models { get; set; }
        public DbSet<Modification> modifications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=exam;Trusted_Connection=True;");
        }
        public MyDBContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Models = new List<Model_>();
            Seed();
        }
        public void Seed()
        {
            Model_ Yaris = new Model_() { Name = "Yaris" };
            Color Red = new Color() { Name = "Red" };
            Color Black = new Color() { Name = "Black" };
            Color Blue = new Color() { Name = "Blue" };
            Modification YarisElegant = new Modification() { Name = "Elegant" };
            Model_ LandCruiser = new Model_() { Name = "Land Cruiser" };
            YarisElegant.colors.Add(Red);
            YarisElegant.colors.Add(Black);
            YarisElegant.colors.Add(Blue);
            Yaris.modifications_.Add(YarisElegant);
            Color White = new Color() { Name = "White" };
            Color DarkGrey = new Color() { Name = "DarkGrey" };
            Modification LandCruiserPremium = new Modification() { Name = "Premium" };
            LandCruiser.modifications_.Add(LandCruiserPremium);
            Modification LandCruiserPrado = new Modification() { Name = "Prado" };
            LandCruiser.modifications_.Add(LandCruiserPrado);
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
        public IEnumerable<Model_> SeachByColor(string ColorName)
        {
            return
            from model in Models
            from modification in model.modifications_
            from _color in modification.colors
            where _color.Name == ColorName
            select model;

        }
        public IEnumerable<Modification> _SeachByColor(string ColorName)
        {
                return
            from model in Models
            from modification in model.modifications_
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
            MyDBContext context = new MyDBContext();
            foreach (var item in context.Models)
            {
                WriteLine($"@@@@@@@@@@@@@@@@@@@@@\n" + $"Модель:\t" + item.
                    ToString());
                {
                    WriteLine($"=======================");
                    foreach (var item_ in item.modifications_)
                    {
                        WriteLine($"Модификация:\t" + item_.ToString());
                        foreach (var _item in item_.colors)
                        {
                            WriteLine($"Доступный цвет:\t" + _item.ToString());

                        }
                        WriteLine($"=======================");
                    }
                }
                WriteLine($"@@@@@@@@@@@@@@@@@@@@@");
            }
        }
    }
}
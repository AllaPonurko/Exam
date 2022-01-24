using Exam.Entities;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext context = new DBContext();
            context.Print();
            context.ChoiceColor();
            string color= context.SeachColor();
            WriteLine($"Цвет\t"+color);
            IEnumerable<Model> Result = context.SeachByColor(color);
            IEnumerable<Modification> ResultMod = context._SeachByColor(color);
            foreach (var item in Result)
            {
                WriteLine($"========================");
                WriteLine(item.ToString()); 
                foreach(var _item in ResultMod)
                {
                    if (item.modifications.Contains(_item))
                        WriteLine(_item.ToString());
                }
            }
            WriteLine($"========================");
        }
    }
}

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
            MyDBContext context = new MyDBContext();
            context.Print();
            context.ChoiceColor();
            string color= context.SeachColor();
            WriteLine($"Цвет\t"+color);
            IEnumerable<Model_> Result = context.SeachByColor(color);
            IEnumerable<Modification> ResultMod = context._SeachByColor(color);
            foreach (var item in Result)
            {
                WriteLine($"========================");
                WriteLine(item.ToString()); 
                foreach(var _item in ResultMod)
                {
                    if (item.modifications_.Contains(_item))
                        WriteLine(_item.ToString());
                }
            }
            WriteLine($"========================");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            VerticalLine vl = new VerticalLine(0, 10, 5, '%'); //создаем вертикальную линию (является наследником фигуры)
            Draw(vl); //вызываем метод Draw

            Point p = new Point(4, 5, '*'); //создаем точку
            Figure fSnake = new Snake(p, 4, Direction.RIGHT); //создаем "змейку" ("змейка" тоже является фигурой)
            //fSnake теперь просто фигура, для нее недоступны методы, специфичные именно для класса Snake
            Draw(fSnake); //вызываем метод Draw, передавая в качестве фигуры fSnake
            Snake snake = (Snake)fSnake; //явное приведение типа, после чего можно использовать методы, относящиеся к классу Snake (которых не было у класса Figure)

            HorizontalLine hl = new HorizontalLine(0, 5, 6, '&'); //создаем горизонтальную линию

            List<Figure> figures = new List<Figure>(); //создаем список фигур
            //вносим в список и "змейку", и вертикальную линию, и горизонтальную линию (так как они все являются фигурами)
            figures.Add(fSnake);
            figures.Add(vl);
            figures.Add(hl);

            foreach (var f in figures) //для всех фигур в списке
            {
                f.DrawLine(); //вызываем метод DrawLine
            }
        }

        static void Draw(Figure figure) //метод Draw принимает в качестве аргумента любую фигуру и вызывает для нее метод DrawLine
        {
            figure.DrawLine();
        }

        //полиморфизм - третья концепция объектно-ориентированного программирования после инкапсуляции и наследования (https://msdn.microsoft.com/ru-ru/library/ms173152.aspx)
    }
}

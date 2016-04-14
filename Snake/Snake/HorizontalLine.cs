using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalLine : Figure //класс HorizontalLine наследуется от класса Figure
    //горизонтальная линия является частным случаем фигуры и класс HorizontalLine содержит всё, что содержится в классе Figure
    {
        //конструктор (метод, который вызывается при создании HorizontalLine) для создания линии
        public HorizontalLine(int xLeft, int xRight, int y, char sym) //параметры (координата по оси X левого конца, координата по оси X правого конца, координата по оси Y, символ)
        {
            pList = new List<Point>(); //пустой список
            //цикл для заполнения списка точками
            for (int x = xLeft; x <= xRight; x++) //на каждой итерации переменная x будет получать значение, начиная от xLeft и заканчивая xRight
            {
                Point p = new Point(x, y, sym); //создание точек с нужными координатами
                pList.Add(p); //добавление точек в список pList
            }            
        }

        public override void DrawLine() //override - ключевое слово для альтернативной реализации метода DrawLine
        {
            Console.ForegroundColor = ConsoleColor.Yellow; //выбираем желтый цвет

            /*
            foreach (Point p in pList) //для всех точек в списке
            {
                p.Draw(); //отрисовка точек желтым цветом
            }
            */

            base.DrawLine(); //вызываем реализацию базового класса метода DrawLine (из класса Figure)

            Console.ForegroundColor = ConsoleColor.White; //изменение цвета на белый
        }
    }
}

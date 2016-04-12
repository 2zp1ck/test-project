using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalLine //класс для отображения горизонтальной линии
    {
        List<Point> pList; //список из точек

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
            /*
            //создаем и добавляем точки в список
            Point p1 = new Point(4, 4, '*');
            Point p2 = new Point(5, 4, '*');
            Point p3 = new Point(6, 4, '*');
            pList.Add(p1);
            pList.Add(p2);
            pList.Add(p3);
            */
        }

        public void DrawHorLine() //метод для вывода линии на экран
        {
            foreach (Point p in pList) //поочередный вывод (через цикл foreach) точек из списка на экран
            {
                p.Draw(); //трижды вызываем метод Draw (для каждой точки из списка pList)
            }
        }
    }
}

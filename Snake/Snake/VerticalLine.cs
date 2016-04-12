using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine //класс для отображения вертикальной линии
    {
        List<Point> pList; //список из точек

        //конструктор (метод, который вызывается при создании VerticalLine) для создания линии
        public VerticalLine(int x, int yTop, int yBottom, char sym) //параметры (координата по оси X, координата по оси Y верхнего конца, координата по оси Y нижнего конца, символ)
        {
            pList = new List<Point>(); //пустой список
            //цикл для заполнения списка точками
            for (int y = yTop; y <= yBottom; y++) //на каждой итерации переменная y будет получать значение, начиная от yTop и заканчивая yBottom
            {
                Point p = new Point(x, y, sym); //создание точек с нужными координатами
                pList.Add(p); //добавление точек в список pList
            }            
        }

        public void DrawVerLine() //метод для вывода линии на экран
        {
            foreach (Point p in pList) //поочередный вывод (через цикл foreach) точек из списка на экран
            {
                p.Draw(); //трижды вызываем метод Draw (для каждой точки из списка pList)
            }
        }
    }
}

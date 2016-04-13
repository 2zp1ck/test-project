using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine : Figure //класс VerticalLine наследуется от класса Figure
    {
        //конструктор (метод, который вызывается при создании VerticalLine) для создания линии
        public VerticalLine(int yUp, int yDown, int x, char sym) //параметры (координата по оси X, координата по оси Y верхнего конца, координата по оси Y нижнего конца, символ)
        {
            pList = new List<Point>(); //пустой список
            //цикл для заполнения списка точками
            for (int y = yUp; y <= yDown; y++) //на каждой итерации переменная y будет получать значение, начиная от yTop и заканчивая yBottom
            {
                Point p = new Point(x, y, sym); //создание точек с нужными координатами
                pList.Add(p); //добавление точек в список pList
            }            
        }
    }
}

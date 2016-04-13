using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //абстрагирование - способ выделить набор значимых характеристик объекта, исключая из рассмотрения незначимые
    class Snake : Figure
    {
        //конструктор для змейки
        public Snake(Point tail, int length, Direction direction) //параметры (координаты хвоста, длина, направление движения)
        {
            pList = new List<Point>(); //создаем пустой список
            for (int i = 0; i < length; i++) //цикл работает, пока значение i меньше значения переменной length
            {
                Point p = new Point(tail); //получаем координаты хвоста
                p.Move(i, direction); //вызываем метод Move класса Point для смещения точки
                pList.Add(p); //заполняем список
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point //класс для обозначения точки (класс может состоять из данных и функций)
    {
        public int x;
        public int y;
        public char sym;

        //конструктор - функция, которая вызывается при создании объекта указанного класса
        public Point() //функция-конструктор никогда ничего не возвращает
        {            
        }

        public Point(int _x, int _y, char _sym)
        { 
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p) //новый конструктор для задания точки с помощью другой точки (точная копия хвоста)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction) //метод для сдвигания точки (расстояние смещения, направление смещения)
        {
            if (direction == Direction.RIGHT) //если смещение вправо, то
            {
                x = x + offset; //увеличиваем координату x на размер смещения
            }
            else if (direction == Direction.LEFT) //если смещение влево, то
            {
                x = x - offset; //уменьшаем координату x на размер смещения
            }
            else if (direction == Direction.UP) //если смещение вверх, то
            {
                y = y - offset; //уменьшаем координату y на размер смещения
            }
            else if (direction == Direction.DOWN) //если смещение вниз, то
            {
                y = y + offset; //увеличиваем координату y на размер смещения
            }
        }

        public void Draw() //функция для вывода символа на экран (входные параметры - координаты и вид символа), void показывает, что функция ничего не возвращает
        {
            Console.SetCursorPosition(x, y); //задаем координаты точки
            Console.Write(sym); //выводим переданный символ в данной позиции
        }

        public override string ToString() //метод для удобства проверки значения переменной Point в отладчике
        {
            return x + ", " + y + ", " + sym;
        }
    }
}

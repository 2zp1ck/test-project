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

        public void Draw() //функция для вывода символа на экран (входные параметры - координаты и вид символа), void показывает, что функция ничего не возвращает
        {
            Console.SetCursorPosition(x, y); //задаем координаты точки
            Console.Write(sym); //выводим переданный символ в данной позиции
        }
    }
}

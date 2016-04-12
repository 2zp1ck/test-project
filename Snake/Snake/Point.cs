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

        public void Draw() //функция для вывода символа на экран (входные параметры - координаты и вид символа)
        {
            Console.SetCursorPosition(x, y); //задаем координаты точки
            Console.Write(sym); //выводим переданный символ в данной позиции
        }
    }
}

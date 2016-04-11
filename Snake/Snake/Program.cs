using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = 1;
            int y1 = 3;            
            char sym1 = '*'; //символ для вывода

            Draw(x1, y1, sym1); //вызов функции для вывода символа в заданной позиции на экран

            int x2 = 4;
            int y2 = 5;
            char sym2 = '#';

            Draw(x2, y2, sym2);

            Console.ReadLine(); //ожидание нажатия Enter от пользователя
        }

        //кусок кода с процедурным подходом (повторяющийся код выносится в отдельную функцию)
        static void Draw(int x, int y, char sym) //функция для вывода символа на экран (входные параметры - координаты и вид символа)
        {
            Console.SetCursorPosition(x, y); //задаем координаты точки
            Console.Write(sym); //выводим переданный символ в данной позиции
        }
    }
}

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
            Point p1 = new Point(); //создаем переменную типа Point
            //задаем координаты x, y и вид символа для переменной p1
            p1.x = 1;
            p1.y = 3;
            p1.sym = '*';            
            //Draw(p1.x, p1.y, p1.sym); //используем функцию Draw для вывода символа на экран
            p1.Draw(); //вызываем метод Draw

            Point p2 = new Point(); //переменная p2 - объект класса Point            
            p2.x = 4;
            p2.y = 5;
            p2.sym = '#';            
            //Draw(p2.x, p2.y, p2.sym);
            p2.Draw();

            /*
            int x1 = 1; //int - целочисленный тип данных
            int y1 = 3;            
            char sym1 = '*'; //символ для вывода (char - символьный тип)

            Draw(x1, y1, sym1); //используем функцию для вывода символа в заданной позиции на экран
            */

            /*
            int x2 = 4;
            int y2 = 5;
            char sym2 = '#';

            Draw(x2, y2, sym2);
            */

            Console.ReadLine(); //ожидание нажатия Enter от пользователя
        }

        //кусок кода с процедурным подходом (повторяющийся код выносится в отдельную функцию)
        /*
        static void Draw(int x, int y, char sym) //функция для вывода символа на экран (входные параметры - координаты и вид символа)
        {
            Console.SetCursorPosition(x, y); //задаем координаты точки
            Console.Write(sym); //выводим переданный символ в данной позиции
        }        
        */
    }
}

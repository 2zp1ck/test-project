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
            Point p1 = new Point(1, 3, '*'); //вызов функции-конструктора с указанием значений x, y, sym
            p1.Draw(); //вызываем метод Draw

            Point p2 = new Point(4, 5, '#'); //переменная p2 - объект класса Point            
            p2.Draw();      
            //инкапсуляция - свойство системы, которое позволяет объединить данные и методы, работающие с ними, в классе и скрыть детали реализации от пользователя

            HorizontalLine line1 = new HorizontalLine(5, 10, 8, '+'); //вызов конструктора с заданными параметрами для создания горизонтальной линии
            line1.DrawHorLine(); //вызов метода DrawHorLine для вывода линии на экран

            VerticalLine line2 = new VerticalLine(7, 10, 17, '*'); //вызов конструктора с заданными параметрами для создания вертикальной линии
            line2.DrawVerLine(); //вызов метода DrawVerLine для вывода линии на экран

            Console.ReadLine(); //ожидание нажатия Enter от пользователя
        }   
    }
}

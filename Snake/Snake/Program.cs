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
            /*
            p1.x = 1;
            p1.y = 3;
            p1.sym = '*';
             */
            p1.Draw(); //вызываем метод Draw

            Point p2 = new Point(4, 5, '#'); //переменная p2 - объект класса Point            
            /*
            p2.x = 4;
            p2.y = 5;
            p2.sym = '#';
            */
            p2.Draw();      
      
            //инкапсуляция - свойство системы, которое позволяет объединить данные и методы, работающие с ними, в классе и скрыть детали реализации от пользователя

            Console.ReadLine(); //ожидание нажатия Enter от пользователя
        }        
    }
}

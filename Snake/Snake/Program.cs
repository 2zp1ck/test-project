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

            List<int> numList = new List<int>(); //переменная numList, которая является объектом класса List, который (объект) будет хранить список целочисленных переменных
            //добавление элементов в список
            numList.Add(2);
            numList.Add(4);
            numList.Add(6);

            int x = numList[0]; //записываем в переменную x значение первого элемента списка
            int y = numList[1]; //записываем в переменную y значение второго элемента списка
            int z = numList[2]; //записываем в переменную z значение третьего элемента списка

            foreach (int i in numList) //цикл foreach (в переменную i на каждом витке цикла записываются поочередно значения всех элементов списка numList)
            {
                Console.WriteLine(i);
            }

            numList.RemoveAt(0); //удаление первого элемента списка (сдвиг влево - второй элемент станет первым)

            List<Point> pList = new List<Point>(); //список, содержащий несколько точек
            //добавляем в список переменные p1 и p2
            pList.Add(p1);
            pList.Add(p2);

            Console.ReadLine(); //ожидание нажатия Enter от пользователя
        }        
    }
}

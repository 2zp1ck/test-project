﻿using System;
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
            //устанавливаем размер окна в консоли
            Console.SetBufferSize(80, 25);
            
            //отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+'); //вызов конструктора с заданными параметрами для создания горизонтальной линии
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');     
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+'); //вызов конструктора с заданными параметрами для создания вертикальной линии
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.DrawLine(); //вызов метода DrawLine для вывода линии на экран
            downLine.DrawLine();
            leftLine.DrawLine();
            rightLine.DrawLine();

            //отрисовка точек
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT); //создаем переменную класса Snake
            snake.DrawLine();

            Console.ReadLine(); //ожидание нажатия Enter от пользователя
        }   
    }
}

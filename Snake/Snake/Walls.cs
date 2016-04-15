using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList; //создаем список фигур для всех стен

        public Walls(int mapWidth, int mapHeight) //конструктор для класса Walls (принимает габариты карты)
        {
            wallList = new List<Figure>();

            // Отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+'); //вызов конструктора с заданными параметрами для создания горизонтальной линии
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+'); //вызов конструктора с заданными параметрами для создания вертикальной линии
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            //добавляем созданные линии в список
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
            //в список попадают объекты разных классов, но все они являются наследниками класса Figure
        }

        //вызываем метод IsHit для переменной figure класса Figure
        internal bool IsHit(Figure figure) //при вызове функции IsHit в качестве аргумента передается "змейка" (но функция принимает любую фигуру)
        {
            foreach (var wall in wallList) //проверяем поочередно каждую стену в списке (переменная wall поочередно принимает значение каждого элемента списка wallList)
            {
                if (wall.IsHit(figure)) //проверяем столкновение (пересечение координат) линии (стенки) и фигуры ("змейки")
                {
                    return true;
                }
            }
            return false;
        }

        public void DrawLine() //альтернативная реализация метода DrawLine
        {
            foreach (var wall in wallList) //для каждой фигуры в списке
            {
                wall.DrawLine(); //поочередный вызов метода DrawLine из класса Figure 
            }
        }
    }
}

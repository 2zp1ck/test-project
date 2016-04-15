using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure //помещаем в класс Figure общий код для классов HorizontalLine и VerticalLine (Figure - базовый класс для своих наследников)
    {
        protected List<Point> pList; //protected - модификатор доступа, чтобы переменная pList была видна у наследников 

        public void DrawLine() //метод для вывода линии на экран        
        {
            foreach (Point p in pList) //поочередный вывод точек из списка на экран
            {
                p.Draw(); //вызываем метод Draw для каждой точки из списка pList
            }
        }

        internal bool IsHit(Figure figure) //функция для проверки столкновения "змейки" со стенкой (принимает в качестве параметра переменную класса Figure)
        {
            //проверка на пересечение точек
            foreach (var p in pList) //для каждой точки (из которых состоит линия стенки) в списке
            {
                //вызываем метод IsHit, принимающий в качестве параметра переменную класса Point
                if (figure.IsHit(p)) //если координаты "змейки" пересекаются с координатами точки линии (препятствия), то
                    return true; //возвращаем true
            }
            return false;
        }

        private bool IsHit(Point point) //метод IsHit, который принимает в качестве параметра переменную класса Point (point - точка из "стенки")
        {
            foreach (var p in pList) //для каждой точки (из которых состоит "змейка") в списке
            {
                if (p.IsHit(point)) //если координаты хотя бы одной из точек "змейки" совпадают с координатами какой-либо точки из списка стен, то
                    return true; //возвращаем true
            }
            return false;
        }

        //наследование - свойство системы, позволяющее писать новый класс на основе уже существующего с частично или полностью замещающейся функциональностью
    }
}

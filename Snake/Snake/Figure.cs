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

        public virtual void DrawLine() //метод для вывода линии на экран
        //virtual означает, что любой наследник может переопределить метод DrawLine и написать свою реализацию данного метода
        {
            foreach (Point p in pList) //поочередный вывод точек из списка на экран
            {
                p.Draw(); //вызываем метод Draw для каждой точки из списка pList
            }
        }

        //наследование - свойство системы, позволяющее писать новый класс на основе уже существующего с частично или полностью замещающейся функциональностью
    }
}

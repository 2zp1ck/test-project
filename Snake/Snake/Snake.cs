using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //абстрагирование - способ выделить набор значимых характеристик объекта, исключая из рассмотрения незначимые
    class Snake : Figure //Snake является наследником класса Figure
    {
        Direction direction; //данные о направлении движения для змейки
        //конструктор для змейки
        public Snake(Point tail, int length, Direction _direction) //параметры (координаты хвоста, длина, направление движения)
        {
            direction = _direction;
            pList = new List<Point>(); //создаем пустой список
            for (int i = 0; i < length; i++) //цикл работает, пока значение i меньше значения переменной length
            {
                Point p = new Point(tail); //получаем координаты хвоста
                p.Move(i, direction); //вызываем метод Move класса Point для смещения точки
                pList.Add(p); //заполняем список
            }
        }

        public void Move()
        {
            Point tail = pList.First(); //метод First возвращает первый элемент списка (хвост змейки)
            pList.Remove(tail); //удаляем полученную точку, так как змейка двигается и точка, соответствующая хвосту, больше не принадлежит змейке
            Point head = GetNextPoint(); //переменная head заполнится значением, которое вернет функция GetNextPoint
            pList.Add(head); //добавление полученной новой точки в список
            
            //в списке pList нет точки, соответствующей хвосту, но она всё еще выведена на экран
            tail.Clear(); //используем метод Clear класса Point для затирания точки
            head.Draw(); //выводим на экран точку с новыми координатами головы змейки с помощью метода Draw
        }

        public Point GetNextPoint() //метод для определения положения головы змейки, возвращает новую точку
        {
            Point head = pList.Last(); //метод Last возвращает последний элемент списка (позиция головы змейки до перемещения)
            Point nextPoint = new Point(head); //создание копии точки с координатами положения головы
            nextPoint.Move(1, direction); //сдвигаем точку на 1 по направлению direction
            return nextPoint; //получение и возврат новой точки с новыми координатами для положения головы
        }

        public bool IsHitTail() //метод для проверки столкновения "змейки" с самой собой
        {
            var head = pList.Last(); //получаем координаты головы "змейки"
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i])) //проверяем совпадения координат головы "змейки" и координат оставшихся в "змейке" точек (метод IsHit для точки)
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key) //публичный метод для проверки значения нажатой клавиши
        {
            if (key == ConsoleKey.LeftArrow) //если была нажата клавиша "<-", то
                direction = Direction.LEFT; //направление змейки изменяется на LEFT
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }

        public bool Eat(Point food) //метод, который возвращает бинарное значение - или правду, или ложь
        {
            Point head = GetNextPoint(); //используем метод для получения точки, соответствующей следующему положению головы "змейки"
            if (head.IsHit(food)) //метод IsHit - если полученная точка (в которой "змейка" окажется на следующем ходу) совпадает с точкой, в которой находится "еда", то
            //if (head.x == food.x && head.y == food.y)
            {
                food.sym = head.sym; //меняем символ "еды" (так как теперь эта точка является частью "змейки")
                pList.Add(food); //добавляем точку food в список точек, из которых состоит "змейка"
                return true; //возвращаем true, так как "змейка" поела
            }
            else //иначе возвращаем false
                return false;
        }
    }
}

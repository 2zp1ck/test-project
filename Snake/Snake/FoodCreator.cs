using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator //класс для генерации точек, соответствующих "еде"
    {
        int mapWidth; //переменная, которая помечается this.
        int mapHeight;
        char sym;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym) //конструктор принимает габариты экрана (ширину и высоту) и символ для отображения "еды"
        {
            this.mapWidth = mapWidth; //через this помечаются переменные, которые являются полями данного класса
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood() //функция для создания точки в произвольном месте на экране (в пределах переданных размеров экрана и с соответствующим символом)
        {
            int x = random.Next(2, mapWidth - 2); //генерация произвольных координат в пределах карты
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym); //возврат новой точки со случайными координатами и заданным символом
        }
    }
}

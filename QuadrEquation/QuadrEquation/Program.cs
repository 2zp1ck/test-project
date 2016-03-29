using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrEquation
{
    class Program
    {
        static float IsNumber(string data) //функция для проверки введенных данных на соответствие типу float
        {
            float number = default(float);

            if (float.TryParse(data, out number))
            {                
                return number;
            }
            Console.WriteLine("Некорректный ввод. Введите, пожалуйста, число:");

            string newData = Console.ReadLine();
            float repeat = IsNumber(newData);
            return repeat;
        }
        
        
        static void Main()
        {
            Console.WriteLine("Решение квадратного уравнения вида: \nax^2 + bx + c = 0\n\nгде a, b, c - коэффициенты; x - свободная переменная.\n");

            Console.WriteLine("Введите коэффициент a:");
            string koefA = Console.ReadLine();
            float a = IsNumber(koefA); //вызов функции для проверки введенных данных на соответствие типу float          

            Console.WriteLine("Введите коэффициент b:");
            string koefB = Console.ReadLine();
            float b = IsNumber(koefB);
            Console.WriteLine("Введите коэффициент c:");
            string koefC = Console.ReadLine();
            float c = IsNumber(koefC);

            float discrim = b * b - 4 * a * c;

            double d = Math.Sqrt(discrim);

            if (a == 0)
            {
                double x = -c / b;
                Console.Write("\nПри a = 0 квадратное уравнение сводится к линейному. Переменная x = {0}.", x);
            }
            else if (a != 0 && discrim > 0) // a = 5; b = 6; c = 1; D = 16; x1= -0,2; x2 = -1
            {
                double x1 = (-b + d) / (2 * a);
                double x2 = (-b - d) / (2 * a);

                Console.Write("\nИмеется 2 действительных корня:\nкорень уравнения x1 = {0};\nкорень уравнения x2 = {1}.", x1, x2);
            }
            else if (a != 0 && discrim == 0) // a = 3; b = 6; c = 3; D = 0; x = -1
            {
                double x = -b / (2 * a);

                Console.Write("\nКорни уравнения совпадают: x1 = x2 = {0}.", x);
            }
            else // a = 1; b = 4; c = 5; D = -4

            Console.Write("\nДискриминант меньше 0. Корней уравнения нет на множестве действительных чисел.");
            
            Console.ReadKey();
        }
    }
}

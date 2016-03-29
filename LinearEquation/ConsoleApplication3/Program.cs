using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static float IsNumber(string data) //функции для проверки введенных данных на число
        {        
            float number = default(float);

            if (float.TryParse(data, out number)) //попытка преобразовать строку в число            
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
            Console.Write("Решение системы линейных уравнений вида:\nax + by = c\ndx + ey = f\n\nгде a, b, c, d, e, f - коэффициенты;\nx, y - неизвестные переменные.\n");
                 
            Console.WriteLine("Введите коэффициент a:"); 

            string koefA = Console.ReadLine();
         
            float a = IsNumber(koefA); //вызов функции для проверки введенных данных на число                                     
            
            Console.WriteLine("Введите коэффициент b:");
            string koefB = Console.ReadLine();
            float b = IsNumber(koefB);
            Console.WriteLine("Введите коэффициент c:");
            string membC = Console.ReadLine();
            float c = IsNumber(membC);
            Console.WriteLine("Введите коэффициент d:");
            string koefD = Console.ReadLine();
            float d = IsNumber(koefD);            
            Console.WriteLine("Введите коэффициент e:");
            string koefE = Console.ReadLine();
            float e = IsNumber(koefE);            
            Console.WriteLine("Введите коэффициент f:");
            string membF = Console.ReadLine();
            float f = IsNumber(membF);

            if (a == d && b == e || a == d && c == f && c != 0 || b == e && c == f && c != 0)
            {
                Console.Write("С заданными коэффициентами решение невозможно. Проверьте входящие данные.");                         
            }

            else
            {
                float x = (c - b * (a * f - c * d) / (a * e - b * d)) / a;
                float y = (a * f - c * d) / (a * e - b * d);

                Console.Write("\nПеременная x = {0}\nПеременная y = {1}", x, y);                
            }

            Console.ReadKey();
        }
    }
}
